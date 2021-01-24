    public TestReflection()
    {
        var typeStr = "System.Int32";
        // resolve the type:
        var lookupType = (from ass in AppDomain.CurrentDomain.GetAssemblies()
                            from t in ass.GetTypes()
                            where t.FullName == typeStr
                            select t).First();
        // get the type of the generic class
        var myType = typeof(MyGenericClass<>);
        // create a generic type
        var myGenericType = myType.MakeGenericType(lookupType);
        var method = myGenericType.GetMethod("ReturnMyType", BindingFlags.Static | BindingFlags.Public);
        // invoke the static method
        var result = (string)method.Invoke(null, new object[0]);
    }
    public static class MyGenericClass<T>
    {
        public static string ReturnMyType()
        {
            return typeof(MyGenericClass<T>).FullName;
        }
    }
