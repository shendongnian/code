    public interface INameable
    {
        string Name {get;set;}
    }
    public static IDictionary<int, T> ReadTable<T>(string tableName)
        where T : INameable, new()
    {
        DataTable dt = GetDataTable(tableName);
        var dictionary = new Dictionary<int, T>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow dr = dt.Rows[i];
            int id = Convert.ToInt32(dr["id"]);
            string name = dr["name"].ToString();
            dictionary[id] = new T() { Name = name };
        }
        return dictionary;
    }
