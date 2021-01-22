    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Timers;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                Timer t1 = new Timer();
                t1.Interval = (1000 * 60 * 20); // 20 minutes...
                t1.Elapsed += new ElapsedEventHandler(t1_Elapsed);
                t1.AutoReset = true;
                t1.Start();
    
                Console.ReadLine();
            }
    
            static void t1_Elapsed(object sender, ElapsedEventArgs e)
            {
                DateTime scheduledRun = DateTime.Today.AddHours(3);  // runs today at 3am.
                System.IO.FileInfo lastTime = new System.IO.FileInfo(@"C:\lastRunTime.txt");
                DateTime lastRan = lastTime.LastWriteTime;
                if (DateTime.Now > scheduledRun)
                {
                    TimeSpan sinceLastRun = DateTime.Now - lastRan;
                    if (sinceLastRun.Hours > 23)
                    {
                        doStuff();
                        // Don't forget to update the file modification date here!!!
                    }
                }
            }
    
            static void doStuff()
            {
                Console.WriteLine("Running the method!");
            }
        }
    }
