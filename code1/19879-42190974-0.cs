    public IQueryable<TEntity> GetWithInclude(Expression<Func<TEntity, bool>> predicate,
                        List<string> sortBy, int pageNo, int pageSize = 12, params string[] include)
            {
                try
                {
                    var numberOfRecordsToSkip = pageNo * pageSize;
                    var dynamic = DbSet.AsQueryable();
    
                    foreach (var s in include)
                    {
                        dynamic.Include(s);
                    }
                     return dynamic.OrderBy("CreatedDate").Skip(numberOfRecordsToSkip).Take(pageSize);
                        
                    
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
