    public static class SomeUtilClass {
        public static TValue VerboseGetValue<TKey, TValue>(
            this IDictionary<TKey, TValue> data, TKey key)
        {
            TValue result;
            if (!data.TryGetValue(key, out result)) {
                throw new KeyNotFoundException(
                    "Key not found: " + Convert.ToString(key));
            }
            return result;
        }
    }
