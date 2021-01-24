    public class ApplicationConfig
    {
         public string Environment => GetValue("Environment");
         public string GetValue(string key) => Environment.GetEnvironmentVariable(key);
    } 
