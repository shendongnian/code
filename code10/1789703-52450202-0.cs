    await dbContext.Set<TEntity>()
        .Where( e => e.Id == entity.Id )
        .Select( e => new
        {
            DoesntMatter01 = e.DBTable1,
            DoesntMatter02 = e.DBTable2,
        } )
        .SingleOrDefaultAsync();
