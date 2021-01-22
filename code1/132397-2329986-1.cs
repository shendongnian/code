    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Text;
    using System.Diagnostics;
    using System.Threading;
    
    namespace MyNameSpace
    {
        class Program
        {
            // APP_GUID can be any unique string.  I just opted for a Guid.  This isn't my real one :-)
            const string APP_GUID = "1F5D24FA-7032-4A94-DA9B-F2B6240F45AC";
    
            static int Main(string[] args)
            {
                bool testMutex = false;
                if (args.Length > 0 && args[0].ToUpper() == "--MUTEX")
                {
                    testMutex = true;
                }
    
                // Got variables, now only allow one to run at a time.
    
                int pid = System.Diagnostics.Process.GetCurrentProcess().Id;
    
                int rc = 0;
    
                Mutex mutex = null;
                bool obtainedMutex = false;
                int attempts = 0;
                int MAX_ATTEMPTS = 4;
    
                try
                {
                    mutex = new Mutex(false, "Global\\" + APP_GUID);
    
                    Console.WriteLine("PID " + pid + " request mutex.");
    
                    while (!obtainedMutex && attempts < MAX_ATTEMPTS)
                    {
                        try
                        {
                            if (!mutex.WaitOne(2000, false))
                            {
                                Console.WriteLine("PID " + pid + " could not obtain mutex.");
                                // Wait up to 2 seconds to get the mutex
                            }
                            else
                            {
                                obtainedMutex = true;
                            }
                        }
                        catch (AbandonedMutexException)
                        {
                            Console.WriteLine("PID " + pid + " mutex abandoned!");
                            mutex = new Mutex(false, "Global\\" + APP_GUID); // Try to re-create as owner
                        }
    
                        attempts++;
                    }
    
                    if (!obtainedMutex)
                    {
                        Console.WriteLine("PID " + pid + " gave up on mutex.");
                        return 102;
                    }
    
    
                    Console.WriteLine("PID " + pid + " got mutex.");
    
                    // This is just to test the mutex... keep one instance open until a key is pressed while
                    // other instances attempt to acquire the mutex
                    if (testMutex)
                    {
                        Console.Write("ENTER to exit mutex test....");
                        Console.ReadKey();
                        return 103;
                    }
    
                    // Do useful work here
    
                }
                finally
                {
                    if (mutex != null && obtainedMutex) mutex.ReleaseMutex();
                    mutex.Close();
                    mutex = null;
                }
    
                return rc;
            }
        }
    }
