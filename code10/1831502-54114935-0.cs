    IEnumerable<BrokenRule> GetBrokenRulesFor(object instance)
    {
        var type = instance.GetType();
        var properties = GetInspectableProperties(type);
    
        foreach (var property in properties)
        {
            if (TypeCanBeEnumeratedAsEntitySequence(property.PropertyType))
            {
                var instanceTypesInCollection = GetEntityTypesFromCollection(instance, property);
                var brokenRulesInCollection = instanceTypesInCollection.Select(x => GetBrokenRulesFor(x)).SelectMany(x => x);
                // ...
            }
        }    
    }
