    public static Dictionary<object,IList<dynamic>> DataTable2Dictionary(DataTable dt)
    {
        Dictionary<object, IList<dynamic>> dict = new Dictionary<dynamic, IList<dynamic>>();
        foreach(DataColumn column in dt.Columns)
        {
            IList<dynamic> ts = dt.AsEnumerable()
                                  .Select(r => r.Field<dynamic>(column.ToString()))
                                  .ToList();
            dict.Add(column, ts);
        }
        return dict;
    }
