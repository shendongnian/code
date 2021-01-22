     static void Main(string[] args)
             {
                 DateTime startTime = DateTime.Now;
                 double root = 0.0;
                 for (int i = 0; i <= 100000000; i++)
                 {
                     root += Math.Sqrt(i);
                 }
                 System.Console.WriteLine(root);
                 TimeSpan runTime = DateTime.Now - startTime;
                 Console.WriteLine("Time elapsed: " +      Convert.ToString(runTime.TotalMilliseconds / 1000));
             }
