    public static IList<T> ToList<T>(this DataTable table) where T : Model, new()
    {
        var list = new List<T>();
        foreach (DataRow dr in table.Rows) {
            T entity = new T();
            entity.Init(table, dr);
            list.Add(entity);
        }
        return list;
    }
