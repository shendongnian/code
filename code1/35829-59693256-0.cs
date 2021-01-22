    public DataTable GenericToDataTable(IList<T> list)
    {
        var json = JsonConvert.SerializeObject(list);
        DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
        return dt;
    }
