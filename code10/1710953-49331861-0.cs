    public static void Retry(int retryCount, TimeSpan delay, Action action)
        {
            bool b = Retry<bool>(
                retryCount,
                delay,
                () => { action(); return true; });
        }
        public static T Retry<T>(int retryCount, TimeSpan delay, Func<T> func)
        {
            int currentAttempt = 0;
            while (true)
            {
                try
                {
                    ++currentAttempt;
                    return func();
                }
                catch
                {
                    if (currentAttempt == retryCount)
                    {
                        throw;
                    }
                }
                if (delay > TimeSpan.Zero)
                {
                    Thread.Sleep(delay);
                }
            }
        }
