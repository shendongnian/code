    private PropertyInfo[] Properties { get; }
    private Func<T, PropertyInfo, object> ExecutableGetter { get; }
    public Constructor()
    {
          Properties = typeof(T).GetProperties();
          Expression<Func<T, PropertyInfo, object>> getter = (tParams, property) => property.GetValue(tParams);
          ExecutableGetter = getter.Compile();
    }
    private int GenerateKey(T requestParams)
    {
        foreach (PropertyInfo property in Properties)
        {
                var propertyValue = ExecutableGetter(requestParams, property);
                // Do stuff with propertyValue
        }
        // ...
    }
