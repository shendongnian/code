    using System;
    using System.IO;
    
    public class Test
    {
        static void Main()
        {
            Random rng = new Random();
            using (TextWriter writer = File.CreateText("test.txt"))
            {
                for (int i = 0; i < 10000; i++)
                {
                    writer.WriteLine("{0} {1} {2}", rng.NextDouble(),
                                     rng.NextDouble(), rng.NextDouble());
                }
            }
        }
    }
