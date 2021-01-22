        if (mutex.WaitOne(0, false))
        {
            try
            {
                Thread.Sleep(10000); // simulate a long operation
                ranJobs = true;
            }
            finally
            {
                mutex.ReleaseMutex();   
            }
        }
