    public IDictionary<int,T> ReadTable<T>(
        string tableName, Action<T, string> onName) 
        where T : new()
    {
        var dictionary = new Dictionary<int,T>();
        DataTable table = GetDataTable(tableName);
        foreach (DataRow row in table.Rows) 
        {
            int id = Convert.ToInt32(row["id"]);
            string name = row["name"].ToString();
            var t = new T();
            onName(t, name);
            dictionary[id] = t;
        }
        return dictionary;
    }
