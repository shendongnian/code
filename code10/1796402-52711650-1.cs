     public class muckingabout
    {
        public bool Exists<T>(object id, object source) where T: class
        {
            Type type = typeof(T);
            var param = Expression.Parameter(type, "e");
            var property = Expression.Property(param, "Id", Expression.Constant(id));
            var body = Expression.Equal(property,);  // stuck here
            var where = Expression.Lambda<Func<T, bool>>(body, param);
            using (var context = new DbContext())
            {
               var dbSet = context.Set<T>();
               return dbSet.AsNoTracking().Any(where);
           }
        }
    }
