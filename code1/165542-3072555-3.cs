    //extension method somewhere
    public static T Cast<T>(this object o)
    {
        return (T)o;
    }
    public remoteStatusCounts(RemoteStatus r)
    {
        Type typeR = r.GetType();
        Type typeThis = this.GetType();
        
        foreach (PropertyInfo p in typeR.GetProperties())
        {
            PropertyInfo thisProperty = typeThis.GetProperty(p.Name);
             
            MethodInfo castMethod = typeof(ExMethods).GetMethod("Cast").MakeGenericMethod(p.PropertyType);
            var castedObject = castMethod.Invoke(null, new object[] { p.GetValue(r, null) });
            thisProperty.SetValue(this, castedObject, null);
        }
    }
