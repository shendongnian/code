    public bool Exists<TEntity>() where TEntity : class
    {
        string entityName = typeof(TEntity).Name;
        ObjectContext objContext = ((IObjectContextAdapter)this).ObjectContext;
        MetadataWorkspace workspace = objContext.MetadataWorkspace;
        return workspace.GetItems<EntityType>(DataSpace.CSpace).Any(e => e.Name == entityName);
    }
