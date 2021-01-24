    static void Main(string[] args)
    {
        var configurationLocation = Assembly.GetEntryAssembly()
            .GetCustomAttribute<ConfigurationLocationAttribute>()
            .ConfigurationLocation;
        Console.WriteLine($"Should get config from {configurationLocation}");
    }
