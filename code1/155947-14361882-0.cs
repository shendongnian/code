    public static class MemoizationExtensions
    {
        public static Func<R> Memoize<R>(this Func<R> f)
        {
            bool hasBeenCalled = false; // Used to determine if we called the function and the result was the same as default(R)
            R returnVal = default(R);
            return () =>
            {
                // Should be faster than doing null checks and if we got a null the first time, 
                // we really want to memoize that result and not inadvertently call the function again.
                if (!hasBeenCalled)
                {
                    hasBeenCalled = true;
                    returnVal = f();
                }
                return returnVal;
            };
        }
    }
