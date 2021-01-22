    public void ReadTable<T>(string tableName, Func<string,T> create) 
    {
        DataTable table = GetDataTable(tableName);
        foreach (DataRow row in table.Rows) 
        {
            int id = Convert.ToInt32(row["id"]);
            string name = row["name"].ToString();
            dictionary[id] = create(name);
        }
    }
