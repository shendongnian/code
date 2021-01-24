    public static IDictionary<string, object> AddProperties(this object obj, List<Item> properties)
    {
        var dictionary = obj.ToDictionary();
        properties.ForEach(x => dictionary.Add(x.Name, x.Vale));
        return dictionary;
    }
