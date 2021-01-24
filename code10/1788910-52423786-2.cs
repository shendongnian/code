    public static string CreateCustomJSON(string serviceName, string value)
    {
        var json = $"{{ \"{serviceName}\":\"{ value}\" }}";
        Console.WriteLine(json);
        return json;
    }
