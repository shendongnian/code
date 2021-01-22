    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Threading;
    using static System.Environment;
[...]
        [DllImport("kernel32.dll") ]
        public static extern UInt64 GetTickCount64(); // Retrieves a 64bit value containing ticks since system start
        static void Main(string[] args)
        {
            const int max = 10_000_000;
            const int n = 3;
            Stopwatch sw;
            // Following Process&Thread lines according to tips by Thomas Maierhofer: https://codeproject.com/KB/testing/stopwatch-measure-precise.aspx
            // But this somewhat contradicts to assertions by MS in: https://msdn.microsoft.com/en-us/library/windows/desktop/dn553408%28v=vs.85%29.aspx?f=255&MSPPError=-2147217396#Does_QPC_reliably_work_on_multi-processor_systems__multi-core_system__and_________systems_with_hyper-threading
            Process.GetCurrentProcess().ProcessorAffinity = new IntPtr(1); // Use only the first core
            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;
            Thread.Sleep(2); // warmup
            Console.WriteLine($"Repeating measurement {n} times in loop of {max:N0}:{NewLine}");
            for (int j = 0; j < n; j++)
            {
                sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < max; i++)
                {
                    var tickCount = GetTickCount64();
                }
                sw.Stop();
                Console.WriteLine($"Measured: GetTickCount64() [ms]: {sw.ElapsedMilliseconds}");
                //
                //
                sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < max; i++)
                {
                    var tickCount = Environment.TickCount; // only int capacity, enough for a bit more than 24 days
                }
                sw.Stop();
                Console.WriteLine($"Measured: Environment.TickCount [ms]: {sw.ElapsedMilliseconds}");
                //
                //
                sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < max; i++)
                {
                    var a = DateTime.UtcNow.Ticks;
                }
                sw.Stop();
                Console.WriteLine($"Measured: DateTime.UtcNow.Ticks [ms]: {sw.ElapsedMilliseconds}");
                //
                //
                sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < max; i++)
                {
                    var a = sw.ElapsedMilliseconds;
                }
                sw.Stop();
                Console.WriteLine($"Measured: Stopwatch: .ElapsedMilliseconds [ms]: {sw.ElapsedMilliseconds}");
                //
                //
                sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < max; i++)
                {
                    var a = Stopwatch.GetTimestamp();
                }
                sw.Stop();
                Console.WriteLine($"Measured: static Stopwatch.GetTimestamp [ms]: {sw.ElapsedMilliseconds}");
                //
                //
                DateTime dt=DateTime.MinValue; // just init
                sw = new Stopwatch();
                sw.Start();
                for (int i = 0; i < max; i++)
                {
                    var a = new DateTime(sw.Elapsed.Ticks); // using variable dt here seems to make nearly no difference
                }
                sw.Stop();
                //Console.WriteLine($"Measured: Stopwatch+conversion to DateTime [s] with millisecs: {dt:s.fff}");
                Console.WriteLine($"Measured: Stopwatch+conversion to DateTime [ms]:  {sw.ElapsedMilliseconds}");
                Console.WriteLine();
            }
            //
            //
            sw = new Stopwatch();
            var tickCounterStart = Environment.TickCount;
            sw.Start();
            for (int i = 0; i < max/10; i++)
            {
                var a = DateTime.Now.Ticks;
            }
            sw.Stop();
            var tickCounter = Environment.TickCount - tickCounterStart;
            Console.WriteLine($"Compare that with DateTime.Now.Ticks [ms]: {sw.ElapsedMilliseconds*10}");
            Console.WriteLine($"{NewLine}General Stopwatch information:");
            if (Stopwatch.IsHighResolution)
                Console.WriteLine("- Using high-resolution performance counter for Stopwatch class.");
            else
                Console.WriteLine("- Using high-resolution performance counter for Stopwatch class.");
            double freq = (double)Stopwatch.Frequency;
            double ticksPerMicroSec = freq / (1000d*1000d) ; // microsecond resolution: 1 million ticks per sec
            Console.WriteLine($"- Stopwatch accuracy- ticks per microsecond (1000 ms): {ticksPerMicroSec:N1}");
            Console.WriteLine(" (Max. tick resolution normally is 100 nanoseconds, this is 10 ticks/microsecond.)");
            DateTime maxTimeForTickCountInteger= new DateTime(Int32.MaxValue*10_000L);  // tickCount means millisec -> there are 10.000 milliseconds in 100 nanoseconds, which is the tick resolution in .NET, e.g. used for TimeSpan
            Console.WriteLine($"- Approximated capacity (maxtime) of TickCount [dd:hh:mm:ss] {maxTimeForTickCountInteger:dd:HH:mm:ss}");
            // this conversion from seems not really accurate, it will be between 24-25 days.
            Console.WriteLine($"{NewLine}Done.");
            while (Console.KeyAvailable)
                Console.ReadKey(false);
            Console.ReadKey();
        }
