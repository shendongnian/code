        using System.Diagnostics;
        public static Double Calculate(CounterSample oldSample, CounterSample newSample)
        {
            double difference = newSample.RawValue - oldSample.RawValue;
            double timeInterval = newSample.TimeStamp100nSec - oldSample.TimeStamp100nSec;
            if (timeInterval != 0) return 100*(1 - (difference/timeInterval));
            return 0;
        }
        static void Main()
        {
            var pc = new PerformanceCounter("Processor Information", "% Processor Time");
            var cat = new PerformanceCounterCategory("Processor Information");
            var instances = cat.GetInstanceNames();
            var cs = new Dictionary<string, CounterSample>();
            
            foreach (var s in instances)
            { 
                pc.InstanceName = s;
                cs.Add(s, pc.NextSample());
            }
            while (true)
            {
                foreach (var s in instances)
                {
                    pc.InstanceName = s;
                    Console.WriteLine("{0} - {1:f}", s, Calculate(cs[s], pc.NextSample()));
                    cs[s] = pc.NextSample();
                }
                System.Threading.Thread.Sleep(500);
            }
        }
    
