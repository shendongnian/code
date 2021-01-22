    using System;
    using System.Diagnostics;
    
    namespace cpuusage
    {
        class Program
        {
            private static DateTime lastTime;
            private static TimeSpan lastTotalProcessorTime;
            private static DateTime curTime;
            private static TimeSpan curTotalProcessorTime;
    
            static void Main(string[] args)
            {
                string processName = "OUTLOOK";
    			
    			Console.WriteLine("Press the any key to stop...\n");
                while (!Console.KeyAvailable)
                {
    				Process[] pp = Process.GetProcessesByName(processName);
    				if (pp.Length == 0)
    				{
    					Console.WriteLine(processName + " does not exist");
    				}
    				else
    				{
    					Process p = pp[0];
    					if (lastTime == null || lastTime == new DateTime())
    					{
    						lastTime = DateTime.Now;
    						lastTotalProcessorTime = p.TotalProcessorTime;
    					}
    					else
    					{
    						curTime = DateTime.Now;
    						curTotalProcessorTime = p.TotalProcessorTime;
    
    						double CPUUsage = (curTotalProcessorTime.TotalMilliseconds - lastTotalProcessorTime.TotalMilliseconds) / curTime.Subtract(lastTime).TotalMilliseconds / Convert.ToDouble(Environment.ProcessorCount);
    						Console.WriteLine("{0} CPU: {1:0.0}%",processName,CPUUsage * 100);
    
    						lastTime = curTime;
    						lastTotalProcessorTime = curTotalProcessorTime;
    					}
    				}
    
    				Thread.Sleep(250);
                }
            }
        }
    }
