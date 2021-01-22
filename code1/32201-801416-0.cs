    public static void dostuff<T, U> (List<T> items)
    {
        foreach (T item in items)
        {
            U obj = ( U )System.Activator.CreateInstance( typeof( U ), item );
            func(obj.SpecialMember);
        }
    }
