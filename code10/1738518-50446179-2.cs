    private string GenerateNameFrom(/*IRow row*/)
    {
        string name = string.Empty;
        var result = Method1(name);
        if (result != null)
            return result;
        result = Method2(name);
        if (result != null)
            return result;
        return Method3(name);
    }
    public static string Method1(string name)
    {
        if (name == "test")
            return "changed";
        return null;
    }
    public static string Method2(string name)
    {
        if (name == "test")
            return "changed";
        return null;
    }
    public static string Method3(string name)
    {
        if (name == "test")
            return "changed";
        return null;
    }
