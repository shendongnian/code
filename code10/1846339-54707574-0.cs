c#
public static class DictionaryExtensions
{
    public static TValue GetOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue @default)
    {
        if (dictionary.ContainsKey(key))
            return dictionary[key];
        return @default;
    }
}
. . .
resultObject.field1 = changesDictionary.GetOrDefault("field1", resultObject.field1);
resultObject.field2 = changesDictionary.GetOrDefault("field2", resultObject.field2);
resultObject.field3 = changesDictionary.GetOrDefault("field3", resultObject.field3);
