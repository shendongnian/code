    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace InputLoop
    {
        class Program
        {
            static long PrintFPSEveryXMilliseconds = 5000;
            static double LimitFPSTo = 10.0;
            static void Main(string[] args)
            {
                ConsoleKeyInfo Key = new ConsoleKeyInfo(' ', ConsoleKey.Spacebar, false, false, false);
                long TotalFrameCount = 0;
                long FrameCount = 0;
                double LimitFrameTime = 1000.0 / LimitFPSTo;
                do
                {
                    Stopwatch FPSTimer = Stopwatch.StartNew();
                    while (!Console.KeyAvailable)
                    {
                        //Start of Tick
                        Stopwatch SW = Stopwatch.StartNew();
    
                        //The Actual Tick
                        Tick();
    
                        //End of Tick
                        SW.Stop();
                        ++TotalFrameCount;
                        ++FrameCount;
                        if (FPSTimer.ElapsedMilliseconds > PrintFPSEveryXMilliseconds)
                        {
                            FrameCount = PrintFPS(FrameCount, FPSTimer);
                        }
                        if (SW.Elapsed.TotalMilliseconds < LimitFrameTime)
                        {
                            Thread.Sleep(Convert.ToInt32(LimitFrameTime - SW.Elapsed.TotalMilliseconds));
                        }
                        else
                        {
                            Thread.Yield();
                        }
                    }
                    //Print out and reset current FPS
                    FrameCount = PrintFPS(FrameCount, FPSTimer);
    
                    //Read input
                    Key = Console.ReadKey();
    
                    //Process input
                    ProcessInput(Key);
                } while (Key.Key != ConsoleKey.Escape);
            }
    
            private static long PrintFPS(long FrameCount, Stopwatch FPSTimer)
            {
                FPSTimer.Stop();
                Console.WriteLine("FPS: {0}", FrameCount / FPSTimer.Elapsed.TotalSeconds);
                //Reset frame count and timer
                FrameCount = 0;
                FPSTimer.Reset();
                FPSTimer.Start();
                return FrameCount;
            }
    
            public static void Tick()
            {
                Console.Write(".");
            }
    
            public static void ProcessInput(ConsoleKeyInfo Key)
            {
                Console.WriteLine("Pressed {0} Key", Key.KeyChar.ToString());
            }
        }
    }
