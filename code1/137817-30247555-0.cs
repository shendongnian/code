    public static bool IsPrimitiveType(object myObject)
    {
       var myType = myObject.GetType();
       return myType.IsPrimitive || myType.Namespace == null ||  myType.Namespace.Equals("System");
    }
