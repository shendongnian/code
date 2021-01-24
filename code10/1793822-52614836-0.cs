    for (int i = 0; i < props.Length; i++)
    {
          var propertyType = props[i].PropertyType;
          var genericArgs = propertyType.GetGenericArguments();
          var container = typeof(GenericPrimitiveContainer<>);
          var containerWithArguments = container.MakeGenericType(genericArgs);
          if (containerWithArguments.IsAssignableFrom(propertyType))
                    // Do something here
    }
