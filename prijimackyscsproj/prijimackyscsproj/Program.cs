using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace skolicky
{
    class Poradnik
    {
        Student[] studenti { get; set; }
        Skola[] skoly { get; set; }

        public void Input()
        {
            string[] zs = Console.ReadLine().Split(' ');
            int[] listik = Array.ConvertAll(zs, s => int.Parse(s));

            int pocetzaci = listik[0];
            int pocetskol = listik[1];

            for (int i = 0; i < pocetzaci; i++)
            {
                string[] naictani = Console.ReadLine().Split(' ');
                int[] dalsinacitani = Array.ConvertAll(zs, s => int.Parse(s));

                Student student = new Student(dalsinacitani, skoly);
            }

            for (int i = 0; i < pocetskol; i++)
            {
                string[] naictani = Console.ReadLine().Split(' ');
                int[] dalsinacitani = Array.ConvertAll(zs, s => int.Parse(s));

                skoly[i] = new Skola(dalsinacitani, studenti);
            }
        }

        public void Priority(int priorita)
        {
            bool konec = true;

            while (konec)
            {
                konec = false;

                foreach (Skola sk in skoly.ToList())
                {
                    foreach (Student st in sk.poradi.ToList())
                    {
                        if (st.skolas[priorita - 1] == sk && sk.prijati.Count < sk.kapacita)
                        {
                            sk.prijati.Add(st);
                            konec = true;

                            foreach (Skola skola in st.skolas.ToList())
                            {
                                if (skola != sk)
                                {
                                    skola.poradi.Remove(st);
                                }
                            }
                        }
                    }
                }
            }


        }

        public void Sort()
        {
            Priority(1);
            Priority(2);
            Priority(3);
        }
    }
    class Student
    {
        public List<Tuple<Skola, int>> skoly { get; set; }
        public int id { get; set; }

        public Student(int[] input, Skola[] skolicky)
        {
            skoly = new List<Tuple<Skola, int>>();

            id = input[0];

            for (int i = 0; i < 3; i++)
            {
                skoly.Add(new Tuple<Skola, int>(skolicky[input[id + 1]], i));
            }
        }
    }
    class Skola
    {
        public int id { get; set; }
        public int kapacita { get; set; }
        public List<Student> poradi { get; set; }

        public Skola(int[] input, Student[] studentici)
        {
            poradi = new List<Student>();

            id = input[0];
            kapacita = input[1];

            for (int i = 0; i < kapacita; i++)
            {
                poradi.Add(studentici[input[i + 2]]);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}