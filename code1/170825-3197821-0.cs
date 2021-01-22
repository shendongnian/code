    public static class MultimapExt
    {
        public static void Add<TKey,TValue>( 
            this Dictionary<TKey,List<TValue>> dictionary, TKey key, TValue value )
        {
            List<TValue> valueList;
            if( !dictionary.TryGetValue( key, out valueList )
            {
                valueList = new List<TValue>();
            }
            valueList.Add( value );
        }
        public static void Remove<TKey,TValue>(
            this Dictionary<TKey,List<TValue>> dictionary, TKey key, TValue value )
        {
            List<TValue> valueList;
            if( dictionary.TryGetValue( key, out valueList ) )
            {
                valueList.Remove( value );
                if( valueList.Count == 0 )
                   dictionary.Remove( key ); 
            }
        }
    }
