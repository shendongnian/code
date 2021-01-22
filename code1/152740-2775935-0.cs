    PropertyInfo inf = typeof(SomeClass).GetProperty("PropertyName");
    Type T = inf.PropertyType;
    object le =
        typeof([TypeThatDeclaresMethod]).GetMethod("GetPropertyOrFieldByName")
        .MakeGenericMethod(typeof(SomeClass), T)
        .Invoke(null, new object[] { "PropertyName" });
