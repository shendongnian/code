    for (int i = 0; i < props.Length; i++)
    {
          var propertyType = props[i].PropertyType;
          if (!propertyType.IsGenericType)
                    continue;
          var genericArgs = propertyType.GetGenericArguments();
          if (genericArgs.Length != 1)
                    continue;
          var container = typeof(GenericPrimitiveContainer<>);
          var containerWithArguments = container.MakeGenericType(genericArgs);
          if (containerWithArguments.IsAssignableFrom(propertyType))
                    // Do something here
    }
