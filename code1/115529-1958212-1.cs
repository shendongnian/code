    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    
    public class Test
    {
        static void Main()
        {   
            Stopwatch sw = Stopwatch.StartNew();
            using (TextReader reader = File.OpenText("test.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] bits = line.Split(' ');
                    foreach (string bit in bits)
                    {
                        double value;
                        if (!double.TryParse(bit, out value))
                        {
                            Console.WriteLine("Bad value");
                        }
                    }
                }
            }
            sw.Stop();
            Console.WriteLine("Total time: {0}ms",
                              sw.ElapsedMilliseconds);
        }
    }
