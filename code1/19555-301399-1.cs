        static TResult TryWithFallback<T, TResult>(Func<T, TResult> primary, Func<T, TResult> fallback, T arg)
        {
            try
            {
                return primary(arg);
            }
            catch
            {
                return fallback(arg);
            }
        }
