    class StackOverflowDetector
    {
        static int Recur()
        {
            Thread.Sleep(1); // simulate that we're actually doing something :-)
            int variable = 1;
            return variable + Recur();
        }
        static void Start()
        {
            try
            {
                int depth = 1 + Recur();
            }
            catch (ThreadAbortException e)
            {
                Console.WriteLine("We've been a {0}", e.ExceptionState);
            }
        }
        static void Main(string[] args)
        {
            // Prepare the execution thread
            Thread t = new Thread(Start);
            t.Priority = ThreadPriority.Lowest;
            // Create the watch thread
            Thread watcher = new Thread(Watcher);
            watcher.Priority = ThreadPriority.Highest;
            watcher.Start(t);
            // Start the execution thread
            t.Start();
            t.Join();
            watcher.Abort();
            Console.WriteLine();
            Console.ReadLine();
        }
        private static void Watcher(object o)
        {
            Thread towatch = (Thread)o;
            while (true)
            {
                if (towatch.ThreadState == System.Threading.ThreadState.Running)
                {
                    towatch.Suspend();
                    var frames = new System.Diagnostics.StackTrace(towatch, false);
                    if (frames.FrameCount > 20)
                    {
                        towatch.Resume();
                        towatch.Abort("Bad bad thread!");
                    }
                    else
                    {
                        towatch.Resume();
                    }
                }
            }
        }
    }
