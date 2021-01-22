    public static class Catching<TException>
    {
        public static bool Try<T>(Func<T> func, out T result)
        {
            try
            {
                result = func();
                return true;
            }
            catch (TException x) 
            {
                // log exception message (with call stacks 
                // and all InnerExceptions)
            }
            result = default(T);
            return false;
        }
        public static T Try<T>(Func<T> func, T defaultValue)
        {
            T result;
            if (Try(func, out result))
                return result;
            return defaultValue;
        }
    }
