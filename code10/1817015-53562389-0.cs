    public static IDictionary<string, object> GetAllProperties(object obj)
    {
        var toret = new Dictionary<string, object>();
        Type objType = obj.GetType();
        PropertyInfo[] properties = objType.GetProperties();
        foreach(PropertyInfo pinfo in properties) {
            toret.Add( pinfo.Name, pinfo.GetValue( obj ) );
        }
        return toret;
    }
