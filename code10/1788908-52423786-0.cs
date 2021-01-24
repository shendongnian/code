    public static string CreateCustomJSON(string serviceName, string value)
    {
        var v = new { serviceName = value };
        string json = $"{{ {serviceName}:\"{ value}\" }}";
        Console.WriteLine(json);
        return json;
    }
