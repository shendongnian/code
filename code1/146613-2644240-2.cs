    using System;
    using System.IO;
    
    class Program
    {
        static void Main()
        {
            int i = 0;
            foreach (string line in File.ReadAllLines("TextFile1.txt"))
            {
                string[] parts = line.Split(',');
                foreach (string part in parts)
                {
                    Console.WriteLine("{0}:{1}",
                        i,
                        part);
                }
                i++;
            }
        }
    }
