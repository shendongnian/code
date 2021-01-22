    public static class DictionaryHelper
    {
        public static TVal Get<TKey, TVal>(this Dictionary<TKey, TVal> dictionary, TKey key, TVal defaultVal = default(TVal))
        {
            TVal val;
            if( dictionary.TryGetValue(key, out val) )
            {
                return val;
            }
            return defaultVal;
        }
    }
