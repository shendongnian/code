    protected List<T> PopulateCollection(DataTable dt) where T: BusinessBase, new()
    {
        return dt.Rows.AsEnumerable().Select(dr => 
        { 
            T t = new T();
            t.PopulateFrom(dr);
        }.ToList();
    }
