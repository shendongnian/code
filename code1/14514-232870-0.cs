    public static class StopwatchExtensions
    {
        public static long Time(this Stopwatch sw, Action action, int iterations)
        {
            sw.Start();
            for (int i = 0; i < iterations; i++)
            {
                action();
            }
            sw.Stop();
            
            return sw.ElapsedMilliseconds;
        }
    }
