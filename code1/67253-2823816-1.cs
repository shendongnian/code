    private string GetEnittySetName(string entityTypeName)
    {
        var container = context.MetadataWorkspace.GetEntityContainer(context.DefaultContainerName, DataSpace.CSpace);
        string entitySetName = (from meta in container.BaseEntitySets
                                where meta.ElementType.Name == entityTypeName
                                select meta.Name).FirstOrDefault();
        return entitySetName;
    }
    
    private string entitySetName;
    
    protected string EntitySetName
    {
        get
        {
            if (string.IsNullOrEmpty(entitySetName))
            {
                entitySetName = GetEnittySetName(typeof(T).Name);
            }
            return entitySetName;
        }
    }
    
    public T SelectOne(Func<T, bool> exp)
    {
        return context.CreateQuery<T>(EntitySetName).Where(exp).FirstOrDefault();
    }
