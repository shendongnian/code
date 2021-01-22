    IEnumerable<T> myEnumerables
    var query=from enumerable in myenumerables
              where some criteria
              orderby GetPropertyValue(enumerable,"SomeProperty")
              select enumerable
    
    private static object GetPropertyValue(object obj, string property)
    {
        System.Reflection.PropertyInfo propertyInfo=obj.GetType().GetProperty(property);
        return propertyInfo.GetValue(obj, null);
    }
