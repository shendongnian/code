    public delegate T CreateObjectDelegate<T>(string name);
    public static void ProcessDataTable<T>(DataTable dt, Dictionary<int, T> dictionary, CreateObjectDelegate<T> createObj)
    {
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            DataRow dr = dt.Rows[i];
            int id = Convert.ToInt32(dr["id"]);
            string name = dr["name"].ToString();
            dictionary[id] = createObj(name);
        }
    }
    static void Main(string[] args)
    {
        var dt = new DataTable();
        var dictionary = new Dictionary<int, BugTracker>();
        ProcessDataTable<BugTracker>(dt, dictionary, (name) => { return new BugTracker() { Name = name }; });
    }
