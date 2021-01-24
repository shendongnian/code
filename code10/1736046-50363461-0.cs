    public static T AddFlag<T>(this ref T e, T flag)
        where T : struct, IConvertible
    {
        if (!(typeof(T).IsEnum)) throw new ArgumentException("Value must be an enum");
        int added = (int)(object)e | (int)(object)flag;
        e = (T)(object)added;
        return e;
    }
