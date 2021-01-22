    using System;
    namespace CsPerfTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                int count = (int)1e8;
                int subcount = 1000;
                double[] roots = new double[subcount];
                DateTime startTime = DateTime.Now;
                for (int i = 0; i < count; i++)
                {
                    roots[i % subcount] = Math.Sqrt(i);
                }
                TimeSpan runTime = DateTime.Now - startTime;
                Console.WriteLine("Time elapsed: " + Convert.ToString(runTime.TotalMilliseconds / 1000));
            }
        }
    }
