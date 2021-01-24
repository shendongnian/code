    public static class FuncHelpers
    {
        public static async Task<T> TryNTimesAsync<T,TException>(this Func<Task<T>> func, int n) where TException : Exception
        {
            while(n-- > 0)
            {
                try
                {
                    return await func();
                }
                catch(TException)
                {
                    if(n <= 0)
                        throw;
                }
            }
            return default(T);
        }
    }
