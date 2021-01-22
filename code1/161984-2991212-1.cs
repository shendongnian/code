    using System;
    using System.IO;
    
    class Test
    {
        static void Main()
        {
            string[] lines = File.ReadAllLines("source\\Staff.txt");
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] fields = line.Split(',');
                if (fields.Length != 6)
                {
                    Console.WriteLine("Invalid line ({0}): {1}",
                                      i + 1, line);
                }
            }
        }
    }
