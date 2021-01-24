     public static T AddIfNotExists<T>(this DbSet<T> dbSet, T entity, Expression<Func<T, bool>> predicate = null) where T : EntityBase
        {
            if(entity.AttributeNullable == null)
            {
                //do some logic
            }
        }
