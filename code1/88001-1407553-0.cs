    public static class Queries
    {
        public static Func<DataContext, int, IQueryable<T>>Get =
            CompiledQuery.Compile<DataContext, int, IQueryable<T>>(
                (DataContext db, int i) => from t in db.GetTable<T>()
                                           where t.ID == i
                                           select t);
    }
    public static class BQueries
    {
        public static Func<DataContext, int, IQueryable<T>> Get =
            CompiledQuery.Compile<DataContext, int, IQueryable<T>>(
                (DataContext db, int id) => from t in A.Queries.Get(db, id)
                                            where !t.Item.Deleted 
                                            select t);
    }
