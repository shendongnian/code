    public static object OBJRet(Type vClasseType)
    {
        return typeof(cFunctions).GetMethod("ObjectReturner2").MakeGenericMethod(vClasseType).Invoke(null, new object[] { });
    }
    public static object ObjectReturner2<T>() where T : new()
    {
        return new T();
    }
