    IEnumerable<TKey> KeysFromValue<TKey, TValue>(this Dictionary<TKey, TValue> dict, TValue val)
    {
        if (dict == null)
        {
            throw new ArgumentNullException("dict");
        }
        return dict.Keys.Where(k => dict[k] == val);
    }
    var keys = greek.KeysFromValue("Beta");
    int exceptionIfNotExactlyOne = greek.KeysFromValue("Beta").Single();
