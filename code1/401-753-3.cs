    public static T GetNewObject<T>()
    {
        try
        {
            return (T)typeof(T).GetConstructor(new Type[] { }).Invoke(new object[] { });
        }
        catch
        {
            return default(T);
        }
    }
