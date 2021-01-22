    // unique id for global mutex - Global prefix means it is global to the machine
    const string mutex_id = "Global\\{B1E7934A-F688-417f-8FCB-65C3985E9E27}";
    static void Main(string[] args)
    {
        using (var mutex = new Mutex(false, mutex_id))
        {
            try
            {
                try
                {
                    if (!mutex.WaitOne(TimeSpan.FromSeconds(5), false))
                    {
                        Console.WriteLine("Another instance of this program is running");
                        Environment.Exit(0);
                    }
                }
                catch (AbandonedMutexException)
                {
                    // Log the fact the mutex was abandoned in another process, it will still get aquired
                }
                // Perform your work here.
            }
            finally
            {
                mutex.ReleaseMutex();
            }
        }
    }
