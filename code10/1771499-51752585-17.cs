    public static class ConfigurationExtensions
    {
        public static bool IsPolicyEnabled(this IConfiguration configuration, string name)
        {
            return configuration?.GetSection("Policy")?[name] == "true";
        }
    }
