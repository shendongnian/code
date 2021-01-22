    public Hashtable GetPropertyInfo(Struct myStruct)
    {
        var properties = new Hashtable();
        Type myType = Type.GetType("Namespace.MyClass");
        PropertyInfo[] propInfo = myType.GetProperties();
        foreach (PropertyInfo prop in propInfo)
        {
             properties.Add(prop.Name, prop.GetValue(myStruct, null));
        }
        return properties;
    }
