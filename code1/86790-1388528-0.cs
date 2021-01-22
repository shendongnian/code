    protected ComplexType _propertyName;
    public ComplexType PropertyName
    {
        get
        {
            return GetProperty(ref _propertyName);
        }
    }
    .
    .
    private T GetProperty<T>(ref T property) where T : new()
    {
      if (property == null)
        property = new T();
      return property;
    }
