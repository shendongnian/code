    public static class StopwatchExtensions
    {
        public static long Time(this Stopwatch sw, Action action, int iterations)
        {
            sw.StartNew(); // thanks to David Humpohl
            for (int i = 0; i < iterations; i++)
            {
                action();
            }
            sw.Stop();
            
            return sw.ElapsedMilliseconds;
        }
    }
