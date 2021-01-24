    public class MyEntity
    {
        public int Id { get; set; }
    }
    public class muckingabout
    {
        public bool Exists<T>(T myentity) where T: MyEntity
        {
            var type = typeof(T);
            //e =>
            var param = Expression.Parameter(type, "e");
            //e => e.Id    
            var property = Expression.Property(param, "Id");
            var value = Expression.Constant(myentity.Id);
            //e => e.Id == myentity.Id
            var body = Expression.Equal(property, value);
            var lambda = Expression.Lambda<Func<T, bool>>(body, param);
    
            using (var context = new DbContext())
            {
               var dbSet = context.Set<T>();
               return dbSet.AsNoTracking().Any(lambda);
            }
        }
    }
