        static bool TryGetTypedValue<TKey, TValue, TActual>(
            this IDictionary<TKey, TValue> data,
            TKey key,
            out TActual value) where TActual : TValue
        {
            TValue tmp;
            if (data.TryGetValue(key, out tmp))
            {
                value = (TActual)tmp;
                return true;
            }
            value = default(TActual);
            return false;
        }
        static void Main()
        {
            Dictionary<string,object> dict
                = new Dictionary<string,object>();
            dict.Add("abc","def");
            string key = "abc", value;
            dict.TryGetTypedValue(key, out value);
        }
