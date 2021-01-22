    class Program
    {
        [DllImport("kernel32.dll")]
        private static extern void QueryPerformanceCounter(ref long ticks);
    
        static void Main()
        {
            long startTicks = 0L;
            QueryPerformanceCounter(ref startTicks);
    
            // some task
    
            long endTicks = 0L;
            QueryPerformanceCounter(ref endTicks);
            long res = endTicks - startTicks;
        }
    }
