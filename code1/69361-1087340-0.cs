    Type MyType = Type.GetType("MyType");
    PropertyInfo[] propInfoArray = MyType.GetProperties();
    ICollection collection = null;
    Object obj = null;
    foreach (PropertyInfo propInfo in propInfoArray)
    {
        if ((obj = propInfo.GetValue(null, null)) is ICollection)
        {
             collection = (ICollection)obj;
        }
    }
