    public static class CustomProviderExtensions
    {
        public static IConfigurationBuilder AddCustomMailConfigProvider(
            this IConfigurationBuilder builder, Action<DbContextOptionsBuilder> dbOptions)
        {
            return builder.Add(new CustomMailConfigSource(dbOptions));
        }
    }
