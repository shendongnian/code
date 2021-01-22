    public static T? NullableParse<T>(string s) where T : struct
    {
        try
        {
            return (T)typeof(T).GetMethod("Parse", new[] {typeof(string)}).Invoke(null, new[] { s });
        }
        catch (Exception)
        {
            return null;
        }
    }
