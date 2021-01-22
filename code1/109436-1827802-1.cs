    namespace ThreadTracker
    {
        using System;
        using System.Threading;
    
        internal class Program
        {
            private static void Main(string[] args)
            {
                TrackedThread thread1 = new TrackedThread(DoNothingForFiveSeconds);
                TrackedThread thread2 = new TrackedThread(DoNothingForTenSeconds);
                TrackedThread thread3 = new TrackedThread(DoNothingForSomeTime);
    
                thread1.Thread.Start();
                thread2.Thread.Start();
                thread3.Thread.Start(15);
                while (TrackedThread.Count > 0)
                {
                    Console.WriteLine(TrackedThread.Count);
                }
    
                Console.ReadLine();
            }
    
            private static void DoNothingForFiveSeconds()
            {
                Thread.Sleep(5000);
            }
    
            private static void DoNothingForTenSeconds()
            {
                Thread.Sleep(10000);
            }
    
            private static void DoNothingForSomeTime(object seconds)
            {
                Thread.Sleep(1000 * (int)seconds);
            }
        }
    }
