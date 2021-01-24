        /// <summary>
        /// Performs the specified action. Only one action with the same Guid may be executing
        /// at a time to prevent race-conditions.
        /// </summary>
        private void ProtectWithMutex(Guid id, Action action)
        {
            // unique id for global mutex - Global prefix means it is global to the machine
            string mutexId = string.Format("Global\\{{{0}}}" ,id);
            using (var mutex = new Mutex(false, mutexId, out bool isNew))
            {
                var hasHandle = false;
                try
                {
                    try
                    {
                        //change the timeout here if desired.
                        int timeout = Timeout.Infinite;
                        hasHandle = mutex.WaitOne(timeout, false);
                        if (!hasHandle)
                        {
                            throw new TimeoutException("A timeout occured waiting for file to become available");
                        }
                    }
                    catch (AbandonedMutexException)
                    {
                        hasHandle = true;
                    }
                    TryAndRetry(action);
                }
                finally
                {
                    if (hasHandle)
                        mutex.ReleaseMutex();
                }
            }
        }
