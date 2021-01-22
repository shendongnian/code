    protected ComplexType _propertyName;
    public ComplexType PropertyName
    {
      get
      {
        return _propertyName ?? (_propertyName = new ComplexType());
      }
    }
