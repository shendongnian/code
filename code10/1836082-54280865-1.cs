    public Type[] GetTypesById(Guid entityId)
    {
        return componentPools
                  .Where(x => ((IDictionary)x.Value)
                      .Contains(entityId))
                  .Select(x => x.Key)
                  .ToArray();
    }
