        private void Run()
        {
            try
            {
                while (!stopping)
                {
                    // do work here
                    // wait for process interval
                    DateTime waitStart = DateTime.Now;
                    while (((DateTime.Now - waitStart).TotalMilliseconds < processInterval) && !stopping)
                    {
                        // give processing time to other threads
                        Thread.Sleep(MSECS_SLEEP_FOR_CHECK);
                    }
                }
                lock (syncObject)
                {
                    stopped = true;
                    stopping = false;
                }
                Helper.WriteToLog(logger, Level.INFO,
                    string.Format("{0} {1}", TASK_NAME, "was stopped."));
            }
            catch (Exception e)
            {
                // log the exception, but ignore it (i.e. don't throw it)
                Helper.LogException(logger, MethodBase.GetCurrentMethod(), e);
            }
        }
