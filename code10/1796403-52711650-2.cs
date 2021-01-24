    public class MyEntity
    {
        public int Id { get; set; }
    }
    public class muckingabout
    {
        public bool Exists<T>(T myentity, Type type) where T: MyEntity
        {
            var param = Expression.Parameter(type, "e");
            var property = Expression.Property(param, "Id", Expression.Constant(myentity.Id));
            var body = Expression.Equal(property);
            var where = Expression.Lambda<Func<T, bool>>(body, param);
    
            using (var context = new DbContext())
            {
               var dbSet = context.Set<T>();
               return dbSet.AsNoTracking().Any(where);
           }
        }
    }
