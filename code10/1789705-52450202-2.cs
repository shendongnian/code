    public Task LoadEntityCollections( DbContext dbContext, IEnumerable<EntityType> entities )
    {
        dbContext.Set<EntityType>()
            .Where( e => entities.Select( ei => ei.Id ).Contains( e.Id ) )
            .Select( e => new
            {
                // assign from properties you want loaded
            } )
            .ToArrayAsync();
    }
