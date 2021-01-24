    using System;
    using System.Threading;
    namespace Demo
    {
        static class Program
        {
            static void Main()
            {
                using (var waitHandle = new EventWaitHandle(true, EventResetMode.AutoReset, "MyHandleName"))
                {
                    Console.WriteLine("Waiting for handle");
                    waitHandle.WaitOne();
                    try
                    {
                        // Body of program goes here.
                        Console.WriteLine("Waited for handle; press RETURN to exit program.");
                        Console.ReadLine();
                    }
                    finally
                    {
                        waitHandle.Set();
                    }
                    Console.WriteLine("Exiting program");
                }
            }
        }
    }
