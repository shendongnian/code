    public static IEnumerable<IDictionary> ToEnumerableDictionary(this IDataReader dataReader)
    {
        var list = new List<Dictionary<string, object>>();
        Dictionary<int, string> keys = null;
        while (dataReader.Read())
        {
            if(keys == null)
            {
                keys = new Dictionary<int, string>();
                for (var i = 0; i < dataReader.FieldCount; i++)
                    keys.Add(i, dataReader.GetName(i));
            }
            var dictionary = keys.ToDictionary(ordinalKey => ordinalKey.Value, ordinalKey => dataReader[ordinalKey.Key]);
            list.Add(dictionary);
        }
        return list.ToArray();
    }
