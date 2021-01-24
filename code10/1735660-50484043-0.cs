    public TEntity Get<TContext>(Expression<Func<TEntity, bool>> predicate, TContext context) where TContext : DbContext
            {
                
                TEntity item = context.Set<TEntity>().FirstOrDefault(predicate);
                return item;
            }
    
            public List<TEntity> GetList<TContext>(Expression<Func<TEntity, bool>> predicate, TContext context) where TContext : DbContext
            {
                List<TEntity> item = context.Set<TEntity>().Where(predicate).ToList();
                return item;
            }
    
            public List<TEntity> GetAll<TContext>(TContext context) where TContext : DbContext
            {
                List<TEntity> item = context.Set<TEntity>().ToList();
                return item;
            }
            
            public TEntity Insert<TContext>(TEntity input, TContext context) where TContext : DbContext
            {
                context.Set<TEntity>().Add(input);
                context.SaveChanges();
                return input;
            }
    
            public TEntity UpSert<TContext>(TEntity input, Expression<Func<TEntity, bool>> predicate, TContext context) where TContext : DbContext
            {
                if (input == null)
                    return null;
    
                TEntity existing = context.Set<TEntity>().FirstOrDefault(predicate);
    
    
    
                if (existing != null)
                {
    
                    input.GetType().GetProperty("Id").SetValue(input, existing.GetType().GetProperty("Id").GetValue(existing));
                    context.Entry(existing).CurrentValues.SetValues(input);
    
                    context.SaveChanges();
                }
                else
                {
                    RemoveNavigationProperties(input);
                    context.Set<TEntity>().Add(input);
                    context.SaveChanges();
                    return input;
                }
    
                return existing;
            }
