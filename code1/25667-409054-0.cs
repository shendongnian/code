    using System;
    using System.IO;
    using System.Text;
    
    class Program
        {
            static void Main(string[] args)
            {
                const string myString = "kdhlkhldhcøehdhkjehdkhekdhk";
                int iterations=getIntFromParams(args, 0, 10);
                int method = getIntFromParams(args, 1, 0);
                var fileName=Path.GetTempFileName();
                using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.Default))
                {
                    switch (method)
                    {
                        case 0:
    
                            Console.WriteLine("Starting method with concatenation. Iterations: " + iterations);
                            var start0 = DateTimeOffset.Now;
                            for (int i = 0; i < iterations; i++)
                            {
                                sw.Write(myString + Environment.NewLine);
                            }
                            var time0 = DateTimeOffset.Now - start0;
                            Console.WriteLine("End at " + time0.TotalMilliseconds + " ms.");
    
                            break;
                        case 1:
                            Console.WriteLine("Starting method without concatenation. Iterations: " + iterations);
                            var start1 = DateTimeOffset.Now;
                            for (int i = 0; i < iterations; i++)
                            {
                                sw.Write(myString);
                                sw.Write(Environment.NewLine);
                            }
                            var time1 = DateTimeOffset.Now - start1;
                            Console.WriteLine("End at " + time1.TotalMilliseconds + " ms.");
                            break;
                        case 2:
                            Console.WriteLine("Starting method without concatenation, using WriteLine. Iterations: " + iterations);
                            var start2 = DateTimeOffset.Now;
                            for (int i = 0; i < iterations; i++)
                            {
                                sw.WriteLine(myString);
                            }
                            var time2 = DateTimeOffset.Now - start2;
                            Console.WriteLine("End at " + time2.TotalMilliseconds + " ms.");
                            break;
                    }
                }
            }
    
            private static int getIntFromParams(string[] args, int index, int @default)
            {
                int value;
                try
                {
                    if (!int.TryParse(args[index], out value))
                    {
                        value = @default;
                    }
                }
                catch(IndexOutOfRangeException)
                {
                    value = @default;
                }
                return value;
            }
      }
 
