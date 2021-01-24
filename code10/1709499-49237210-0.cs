    public static class SomeListExtensions
    {
        public static void Expand<T>( this List<T> list, int count )
        {
            if ( count < list.Count )
            {
                list.RemoveRange( count, list.Count - count );
            }
            else if ( count > list.Count )
            {
                int oldCount = list.Count;
                for ( int i = oldCount; i < count; i++ )
                    list.Add( list[ i % oldCount ] );
            }
        }
    }
