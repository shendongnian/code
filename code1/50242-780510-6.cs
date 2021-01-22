    protected List<T> PopulateCollection<T>(DataTable dt)
        where T: BusinessBase, new()
    {
        return dt.AsEnumerable().Select(dr => 
        { 
            T t = new T();
            t.PopulateFrom(dr);
        }.ToList();
    }
