    public IQueryable<TEntity> GetEntities<TEntity>()
    {
        Type t = typeof(TEntity);
        var edmAttr = (EdmEntityTypeAttribute)Attribute.GetCustomAttribute(t,
            typeof(EdmEntityTypeAttribute), false);
        if (edmAttr == null)  // Fall back to the naive way
        {
            return context.CreateQuery<TEntity>(t.Name);
        }
        var ec = context.MetadataWorkspace.GetEntityContainer(
            context.DefaultContainerName, DataSpace.CSpace);
        var entityType = context.MetadataWorkspace.GetType(edmAttr.Name,
            edmAttr.NamespaceName, DataSpace.CSpace);
        return ec.BaseEntitySets.First(es => es.ElementType == entityType);
    }
