    static Dictionary<string, PropertyInfo> propertyMap = new Dictionary<string, PropertyInfo>();
    static MyClass()
    {
         Type myClass = typeof(MyClass);
         // For each property you want to support:
         propertyMap.Add("as_billaddress", MyClass.GetProperty("BillAddress"));
         // ...
    }
