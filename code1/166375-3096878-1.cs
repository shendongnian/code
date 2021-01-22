    public static void RemoveAllOfType<T>( this IList list )
    {
        for( int index = list.Count - 1; index >= 0; index -- )
        {
            if( list[index] is T )
            {
                list.RemoveAt( index );
            }
        }
    }
