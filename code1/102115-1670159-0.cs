    public List<T> GetQueryResult<T>(string xPathQuery)
    {
        var items = ;// logic to get items
        var list = new List<T>();
        foreach (Sitecore.Data.Items.Item item in items)
        {
            list.Add((T) Activator.CreateInstance(typeof(T), item));
        }
        
        return list;
    }
