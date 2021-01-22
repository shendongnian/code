    public static object MakeList( string typeStr )
    {
        var nameSpace = "MyTestApplication" + ".";
        var objType = Type.GetType(nameSpace + typeStr); // NAMESPACE IS REQUIRED
        var listType = typeof(List<>).MakeGenericType(objType);
        return Activator.CreateInstance(listType);
    }
    var listOfThings = MakeList("MyCoolObject") as List<MyCoolObject>;
