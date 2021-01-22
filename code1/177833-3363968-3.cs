    public static void Fill<T>(this List<T> lst, T val)
    {
        Fill(lst, val, lst.Capacity);
    }
    public static void Fill<T>(this List<T> lst)
    {
        Fill(lst, default(T), lst.Capacity);
    }
