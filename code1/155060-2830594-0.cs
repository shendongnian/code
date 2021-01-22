    using System;
    using System.Threading;
    
    public class EntryPoint
    {
        private static void ThreadFunc()
        {
            try
            {
                ulong counter = 0;
                while (true)
                {
                    try
                    {
                        Console.WriteLine("{0}", counter++);
                    }
                    catch (ThreadAbortException)
                    {
                        // Attempt to swallow the exception and continue.
                        Console.WriteLine("Abort!");
                     }
                }
            }
            catch(ThreadAbortException)
            {
                Console.WriteLine("Certainly unstoppable!");
            }
        }
    
        static void Main()
        {
            try
            {
                Thread newThread = new Thread(new ThreadStart(EntryPoint.ThreadFunc));
                newThread.Start();
                Thread.Sleep(2000);
    
                // Abort the thread.
                newThread.Abort();
    
               // Wait for thread to finish.
               newThread.Join();
            }
           catch (Exception e)
           {
               Console.WriteLine(e.ToString());
           }
        }
    }
