    private static void RunTest(string appName)
    {
        bool done = false;
        PerformanceCounter total_cpu = new PerformanceCounter("Process", "% Processor Time", "_Total");
        PerformanceCounter process_cpu = new PerformanceCounter("Process", "% Processor Time", appName);
        while (!done)
        {
            float t = total_cpu.NextValue();
            float p = process_cpu.NextValue();
            Console.WriteLine(String.Format("_Total = {0}  App = {1} {2}%\n", t, p, p / t * 100));
            System.Threading.Thread.Sleep(1000);
        }
    }
