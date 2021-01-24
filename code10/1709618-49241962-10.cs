    var properties = instance.GetType().GetProperties();
    foreach (var property in properties){
        // Let's emphasize here that we don't know the type by using
        // object instead of var
        object value = property.GetValue(instance);
        
        // We need to bail if this is null.
        if (value == null)   
          continue;
        if (value is ISomeThing someThingValue && someThingValue.IsSomeCondition)
        {
            // Do a ISomeThing-specific thing here
        }
        else if (property.PropertyType.GetInterfaces().Concat(new []{property.PropertyType})
            .Any(i => i.IsGenericType 
                  && i.GetGenericTypeDefinition() == typeof(ICollection<>)
                  && typeof(ISomeThing).IsAssignableFrom(i.GetGenericArguments().Single())))
        {
            var ie = value as IEnumerable;
            Debug.Assert(ie != null);
            foreach (ISomeThing someThingInstance in ie.OfType<ISomeThing>())
            {
                if(someThingInstance.IsSomeCondition)
                {
                    // Do the thing again
                }
            }
        }
        // Enter recursion for possible nested ISomeThings
    }
