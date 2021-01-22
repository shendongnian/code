        public override void OnStart()
        {
            while (stopping)
            {
                Thread.Sleep(MSECS_SLEEP_FOR_STOP);
            }
            lock (syncObject)
            {
                // make sure task isn't already started
                if (!stopped)
                {
                    Helper.WriteToLog(logger, Level.INFO,
                        string.Format("{0} {1}", TASK_NAME, "is already started."));
                    return;
                }
                stopped = false;
            }
            // start task in new thread
            Thread thread = new Thread(Run);
            thread.Start();
            Helper.WriteToLog(logger, Level.INFO,
                string.Format("{0} {1}", TASK_NAME, "was started."));
        }
