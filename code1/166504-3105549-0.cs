    else if (p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(EntityCollection<>))
    {
        IEnumerable pEnum = (IEnumerable)p.GetValue(entity, null);
    
        IRelatedEnd pEnd = (IRelatedEnd)p.GetValue(entity, null);
        pEnd.Load();
    
        // Load child entities
        IEnumerator eEnum = pEnum.GetEnumerator();
        while (eEnum.MoveNext())
        {
            LoadAllRelatedEntities((EntityObject)eEnum.Current, ref processed);
        }
    }
