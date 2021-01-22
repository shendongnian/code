    static class CreatorFatory<T> where T : new() {
        public static readonly Func<T> Method = 
            Expression.Lambda<Func<T>>(Expression.New(typeof(T)).Compile();
    }
    
    public static IList<T> ToList<T>(this DataTable table) where T : Model {
        var entities = table.Rows.Select(r => CreatorFactory<T>.Method()).ToList();
        for (int i = 0; i < table.Rows.Count; i++)
            entities[i].Init(table, table.Rows[i]);
        return entities;
    }
