    public override IPropertyMap Map(Func<T, string> fetcher)
    {
        var propertyMap = new FixedLengthPropertyMap
              {
                  //Length = 20,
                  //PaddingCharacter = " ",
                  PadLeft = false,
                  Delegate = fetcher // Delegate is of type Delegate
              };
    
        _properties.Add(propertyMap);
    
        return propertyMap;
    }
