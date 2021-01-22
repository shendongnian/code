    using System.Runtime;
    class Program
    {
        static void Main()
        {
            GCSettings.LatencyMode = GCLatencyMode.LowLatency;
        }
    }
