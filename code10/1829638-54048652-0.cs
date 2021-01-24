    using System;
    using System.Linq;
    namespace _05_01_19_5am
    {
        class Program
        {
            public static void Main()
            {
                Random random = new Random();
                String[] students = { "Fred", "Mary", "Yusef", "Kyle", "Sophie", "Lydia", "Max", "Donald", "Yasmin", "Archie" };
                var shuffleThem = students.OrderBy(s => Guid.NewGuid()).ToArray();
                for (int i = 0; i < 5; i++)
                {
                Console.WriteLine(shuffleThem[i] + " + " + shuffleThem[i+1]);
                }
            }
        }
    }
