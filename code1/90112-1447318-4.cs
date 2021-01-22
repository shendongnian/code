    var stringPropertyNamesAndValues = myObject.GetType()
        .GetProperties()
        .Where(pi => pi.PropertyType == typeof(string) && pi.GetGetMethod() != null)
        .Select(pi => new 
        {
            Name = pi.Name,
            Value = pi.GetGetMethod().Invoke(myObject, null)
        });
