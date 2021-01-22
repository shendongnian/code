    //extension method somewhere
    public static T Cast<T>(this object o)
    {
        return (T)o;
    }
    Type typeR = r.GetType();
    Type typeThis = this.GetType();
    
    foreach (PropertyInfo p in t.GetProperties())
    {
        PropertyInfo thisProperty = typeThis.GetProperty(p.Name);
         
        MethodInfo castMethod = typeof(ExMethods).GetMethod("Cast").MakeGenericMethod(p.PropertyType);
        var castedObject = castMethod.Invoke(null, new object[] { p.GetValue(typeR, null) });
        thisProperty.SetValue(this, castedObject, null);
    }
