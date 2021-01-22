    public static object GetNewObject(Type t)
    {
        try
        {
            return t.GetConstructor(new Type[] { }).Invoke(new object[] { });
        }
        catch
        {
            return null;
        }
    }
