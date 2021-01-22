    public static void Fill<T>(this ICollection<T> lst, int num)
    {
        Fill(lst, default(T), num);
    }
    
    public static void Fill<T>(this ICollection<T> lst, T val, int num)
    {
        lst.Clear();
        for(int i = 0; i < num; i++)
            lst.Add(val);
    }
