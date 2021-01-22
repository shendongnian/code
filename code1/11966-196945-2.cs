    var properties = this.GetType().GetProperties();
    foreach (PropertyInfo p in properties)
    {
        object value = typeof(MyClass)
        .GetMethod("DoStuff")
        .MakeGenericMethod(p.PropertyType)
        .Invoke(null, new object[] { p.Name });
        p.SetValue(this, value, null);
    }
