    public static IList<T> ToList<T>(this DataTable table)
        where T : IDataModel, new()
    {
        IList<T> results = new List<T>();
    
        foreach (DataRow row in table.Rows)
        {
            T item = new T();
            item.FromDataRow(row);
            results.Add(item);
        }
    
        return users;
    }
