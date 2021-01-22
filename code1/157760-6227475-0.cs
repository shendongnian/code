    public static Dictionary<TKey, TValue>  DeserializeDictionary<TKey, TValue>(this JavaScriptSerializer jss, string jsonText)
    {
        var dictWithStringKey = jss.Deserialize<Dictionary<string,TValue>>(jsonText);
        var dict=dictWithStringKey.ToDictionary(de => jss.ConvertToType<TKey>(de.Key),de => de.Value);
            return dict;
    }
