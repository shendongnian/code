    using System.Reflection;
    public void Create(string myType, string myValue)
    {
        Type type = Type.GetType(myType);
        if (type.IsPrimitive)
        {
            MethodInfo Parse = type.GetMethod("Parse");
            Parse.Invoke(null, new object[] { myValue });
            ...
        }
    }
