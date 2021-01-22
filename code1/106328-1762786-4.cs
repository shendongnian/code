    public static T? CastOrThrow<T>(this object x) 
        where T : struct
    {
        T? ret = x as T?;
        if (ret == null)
        {
            throw new Exception(); // Again, get a better exception
        }
        return ret;
    }
