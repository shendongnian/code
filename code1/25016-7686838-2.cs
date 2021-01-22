    public static T Convert<T>()
    {
        if (typeof(T) == typeof(int))
        {
            int a = 5;
            T value = __refvalue(__makeref(a), T);
            return value;
        }
        else if (typeof(T) == typeof(long))
        {
            long a = 6;
            T value = __refvalue(__makeref(a), T);
            return value;
        }
            
        throw new NotImplementedException();
    }
