    private static void Delete<TEntity>(DbContext dbContext, IEnumerable<TEntity> seedRows)
        where TEntity : class//, IBaseEntity
    {
    	var entityType = dbContext.Model.FindEntityType(typeof(TEntity));
    	var entityPK = entityType.FindPrimaryKey();
    	var dbEntity = Expression.Parameter(entityType.ClrType, "e");
    	Expression matchAny = null;
    	foreach (var entity in seedRows)
    	{
    		var match = entityPK.Properties
    			.Select(p => Expression.Equal(
    				Expression.Property(dbEntity, p.PropertyInfo),
    				Expression.Property(Expression.Constant(entity), p.PropertyInfo)))
    			.Aggregate(Expression.AndAlso);
    		matchAny = matchAny != null ? Expression.OrElse(matchAny, match) : match;
    	}
        var dbQuery = dbContext.Set<TEntity>().AsQueryable();
    	if (matchAny != null)
        {
    	    var predicate = Expression.Lambda<Func<TEntity, bool>>(Expression.Not(matchAny), dbEntity);
            dbQuery = dbQuery.Where(predicate);
        }
    	var dbEntities = dbQuery.ToList();
    	if (dbEntities.Count == 0) return;
    	dbContext.RemoveRange(dbEntities);
    	dbContext.SaveChanges();
    }
