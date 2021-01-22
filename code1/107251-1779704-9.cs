    public IDictionary<int,T> ReadTable<T>(string tableName, Func<string,T> create) 
    {
        DataTable table = GetDataTable(tableName);
        var dictionary = new Dictionary<int,T>()
        foreach (DataRow row in table.Rows) 
        {
            int id = Convert.ToInt32(row["id"]);
            string name = row["name"].ToString();
            dictionary[id] = create(name);
        }
        return dictionary;
    }
