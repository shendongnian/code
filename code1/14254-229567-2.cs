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
                        // note, you may want to time out here instead of waiting forever
                        //mutex.WaitOne(Timeout.Infinite, false);
                        //acidzombie24 edit
                        var isSingle = mutex.WaitOne(5000);
                        if (isSingle == false) return;//another instance exist
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
