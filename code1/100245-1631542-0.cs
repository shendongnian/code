        static void Main(string[] args)
        {
            Stopwatch sw;
            sw = Stopwatch.StartNew();
            int i = 0;
            while (sw.ElapsedMilliseconds <= 5000)
            {
                if (sw.Elapsed.Ticks % 100 == 0)
                { i++; /* do something*/ }
            }
            sw.Stop();
           
        }
