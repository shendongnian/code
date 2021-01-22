    public static IList<T> ToList<T>(this DataTable table, Func<T> creator) where T : Model {
        T[] entities = new T[table.Rows.Count];
        for (int i = 0; i < table.Rows.Count; i++)
            entities[i] = creator();
        //...
    }
