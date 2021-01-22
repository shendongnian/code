        static void udelay(long us)
        {
            var sw = System.Diagnostics.Stopwatch.StartNew();
            long v = (us * System.Diagnostics.Stopwatch.Frequency )/ 1000000;
            while (sw.ElapsedTicks < v)
            {
            }
        }
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("" + i + " " + DateTime.Now.Second + "." + DateTime.Now.Millisecond);
                udelay(1000000);
            }
        }
