    public static class DictionaryExt {
        public static TValue FindOrDefault<TKey,TValue>( 
                this Dictionary<TKey,TValue> dic,
                TKey key, TValue defaultValue )  
        {
            TValue val;
            return dic.TryGetValue( key, out val ) ? val : defaultValue;
        }
    }
    enumeration.Select( d => d.FindOrDefault( "some key", float.NaN ) )
               .Where ( f => f != float.NaN );
