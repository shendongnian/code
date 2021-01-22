    public class RetryManager 
    {
        public void Do(Action action, 
                        TimeSpan interval, 
                        int retries = 3)
        {
            Try<object, Exception>(() => {
                action();
                return null;
            }, interval, retries);
        }
        public T Do<T>(Func<T> action, 
                        TimeSpan interval, 
                        int retries = 3)
        {
            return Try<T, Exception>(
                  action
                , interval
                , retries);
        }
        public T Do<E, T>(Func<T> action, 
                           TimeSpan interval, 
                           int retries = 3) where E : Exception
        {
            return Try<T, E>(
                  action
                , interval
                , retries);
        }
        public void Do<E>(Action action, 
                           TimeSpan interval, 
                           int retries = 3) where E : Exception
        {
            Try<object, E>(() => {
                action();
                return null;
            }, interval, retries);
        }
        private T Try<T, E>(Func<T> action, 
                           TimeSpan interval, 
                           int retries = 3) where E : Exception
        {
            var exceptions = new List<E>();
            for (int retry = 0; retry < retries; retry++)
            {
                try
                {
                    if (retry > 0)
                        Thread.Sleep(interval);
                    return action();
                }
                catch (E ex)
                {
                    exceptions.Add(ex);
                }
            }
            throw new AggregateException(exceptions);
        }
    }
