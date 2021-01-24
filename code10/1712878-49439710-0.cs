    public abstract class IDbTable : IDisposable
    {
        public void Dispose()
        {
            // do disposing if you need
        }
    }
    public static class DB
    {
        public static long Insert<T>(this T entity) where T : IDbTable
        {
            using (var db = ConFactory.GetConnection())
            {
                    db.Open();
                    return db.Insert(entity);
            }
        }
        public static void Delete<T>(this T entity) where T : IDbTable
        {
                using (var db = ConFactory.GetConnection())
                {
                    db.Open();
                    db.Delete(entity);
                }
        }
        public static void Update<T>(this T entity) where T : IDbTable
        {
                using (var db = ConFactory.GetConnection())
                {
                    db.Open();
                    SqlMapperExtensions.Update(db, entity);
                }
        }
        public static T Get<T>(int id)
        {
            using (var db = ConFactory.GetConnection())
            {
                db.Open();
                return db.Get<T>(id);
            }
        }
    }
