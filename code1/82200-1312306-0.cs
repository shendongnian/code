    var prop = footype.GetProperty("bars");
    // In case you want to retrieve the time of item in the list (but actually you don't need it...)
    //var typeArguments = prop.PropertyType.GetGenericArguments();
    //var listItemType = typeArguments[0];
    var lst = Activator.CreateInstance(prop.PropertyType);
    prop.SetValue(foo, lst, null);
