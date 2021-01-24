    public static class DictionaryExtension
    {
        public static bool ContainsKeyIgnoreCase<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            bool? keyExists;
            var keyString = key as string;
            if (keyString != null)
            {
                // Key is a string.
                // Using string.Equals to perform case insensitive comparison of the dictionary key.
                keyExists =
                    dictionary.Keys.OfType<string>()
                    .Any(k => string.Equals(k, keyString, StringComparison.InvariantCultureIgnoreCase));
            }
            else
            {
                // Key is any other type, use default comparison.
                keyExists = dictionary.ContainsKey(key);
            }
            return keyExists ?? false;
        }
    }
