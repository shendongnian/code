    class Program
    { 
        private static IConfigurationRoot Configuration;
        const string SecretName= "SecretName";
        private static void Main(string[] args)
        {
            BootstrapConfiguration();
            Console.WriteLine($"The Secret key is {Configuration[SecretName]}");
        }
    }
    private static void BootstrapConfiguration()
    {
        string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        if (string.IsNullOrWhiteSpace(env))
        {
            env = "Development";
        }
        var builder = new ConfigurationBuilder();
        if (env == "Development")
        {
            builder.AddUserSecrets<Program>();
        }
        Configuration = builder.Build();
    }
