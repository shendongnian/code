    public static T? Parse(string s)
    {
        Type type = typeof(T);
        string tName = type.Name;
        MethodInfo methodInfo = type.GetMethod("TryParse", new[] { typeof(string), type.MakeByRefType() });
        object[] args = new object[] { s, null };
        bool parsed = (bool)methodInfo.Invoke(null, args);
        dynamic result = parsed ? args[1] : null;
        return result;
    }
