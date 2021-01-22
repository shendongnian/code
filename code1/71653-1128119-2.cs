    public static IEnumerable<T> ToEnumerable<T>(this DataTable table) where T : Model, new()
    {
        foreach (DataRow row in table.Rows)
        {
            T entity = new T();
            entity.Init(table, row);
  
            yield return entity;
        }
    }
