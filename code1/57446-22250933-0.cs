    public static bool IsParseableAs(this string value, Type type) {
        var tryParseMethod = type.GetMethod("TryParse", BindingFlags.Static | BindingFlags.Public, Type.DefaultBinder,
            new[] { typeof(string), type.MakeByRefType() }, null);
        if (tryParseMethod == null) return false;
        var arguments = new[] { value, Activator.CreateInstance(type) };
        return (bool) tryParseMethod.Invoke(null, arguments);
    }
