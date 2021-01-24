    public void PrettyPrint(string message, object kvp)
    {
        Console.WriteLine(message);
        var json = JsonConvert.SerializeObject(kvp, Formatting.Indented);
        Console.WriteLine(json);
    }
