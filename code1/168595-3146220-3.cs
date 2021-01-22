    public static void AddItem<T>( this T[] array, T item )
    {
        List<T> list = array.ToList();
        list.Add( item );
        array = list.ToArray(); /* Untested, this may not compile! */
    }
