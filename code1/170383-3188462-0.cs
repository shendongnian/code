    public static class DictionaryExt
    {
        // bundles up safe dictionary lookup with value conviersion...
        // could be split apart for improved maintenance if you like...
        public static TResult ValueOrDefault<TKey,TValue,TResult>( 
            this DIctionary<TKey,TValue> dictionary, TKey key, TResult defaultVal )
        {
            TValue value;
            return dictionary.TryGetValue( key, out value ) 
              ? Convert.ChangeType( value, typeof(TResult) )
              : defaultVal;
        }
    }
