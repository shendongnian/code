        private static double Floor1Test()
        {
            // Keep track of results in total so ops aren't optimized away.class Program
            double total = 0;
            for (int i = 0; i < 100000000; i++)
            {
                float f = 5.13f;
                double d = 5.13;
                float fp = f - (float)Math.Floor(f);
                double dp = d - (float)Math.Floor(d);
                total = fp + dp;
            }
            return total;
        }
        private static double Floor2Test()
        {
            // Keep track of total so ops aren't optimized away.
            double total = 0;
            for (int i = 0; i < 100000000; i++)
            {
                float f = 5.13f;
                double d = 5.13;
                float fp = f - (int)(f);
                double dp = d - (int)(d);
                total = fp + dp;
            }
            return total;
        }
        static void Main(string[] args)
        {
            System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            // Unused run first, guarantee code is JIT'd.
            timer.Start();
            Floor1Test();
            Floor2Test();
            timer.Stop();
            timer.Reset();
            timer.Start();
            Floor1Test();
            timer.Stop();
            long floor1time = timer.ElapsedMilliseconds;
            timer.Reset();
            timer.Start();
            Floor2Test();
            timer.Stop();
            long floor2time = timer.ElapsedMilliseconds;
            Console.WriteLine("Floor 1 - {0} ms", floor1time);
            Console.WriteLine("Floor 2 - {0} ms", floor2time);
        }
    }
