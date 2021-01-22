    internal static class NativeMethods
    {
        [DllImport("Kernel32.dll")]
        public static extern void QueryPerformanceCounter(ref long ticks); 
    }
