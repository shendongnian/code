    protected List<T> PopulateCollection(DataTable dt) where T: BusinessBase, new()
    {
        List<T> lst = new List<T>();
        foreach (DataRow dr in dt.Rows)
        {
            T t = new T();
            t.PopulateFrom(dr);
            lst.Add(t);
        }
        return lst;
    }
