        /// <summary>
        /// Trys to perform the specified action a number of times before giving up.
        /// </summary>
        private void TryAndRetry(Action action)
        {
            int failedAttempts = 0;
            while (true)
            {
                try
                {
                    action();
                    break;
                }
                catch (IOException ex)
                {
                    if (++failedAttempts > RetryCount)
                    {
                        throw;
                    }
                    Thread.Sleep(RetryInterval);
                }
            }
        }
