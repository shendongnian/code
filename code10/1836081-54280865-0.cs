    public Type[] GetTypesById(Guid entityId)
    {
        return componentPools
                  .Where(x => ((IDictionary)x.Value)
                      .Cast<dynamic>
                      .Any(y => y.Key == entityId))
                  .Select(x => x.Key)
                  .ToArray();
    }
