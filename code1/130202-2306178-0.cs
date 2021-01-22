    DataTable table = new DataTable();
    table.Colums.Add("key", typeof(string));
    table.Colums.Add("value", typeof(string));
    
    foreach (DictionaryEntry entry in HttpRuntime.Cache)
    {
        table.AddRow(entry.Key, entry.Value);
    }
