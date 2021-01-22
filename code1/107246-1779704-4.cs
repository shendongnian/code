    public void ReadTable<T>(string tableName, Action<T, string> onName) 
        where T : new()
    {
        DataTable table = GetDataTable(tableName);
        foreach (DataRow row in table.Rows) 
        {
            int id = Convert.ToInt32(row["id"]);
            string name = row["name"].ToString();
            var t = new T();
            onName(t, name);
            dictionary[id] = t;
        }
    }
