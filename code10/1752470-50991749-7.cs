    public static class MyLoggingBuilderExtensions {
        public static ILoggingBuilder AddProvider<T>(this ILoggingBuilder builder)
            where T: class, ILoggerProvider{
            builder.Services.AddSingleton<ILoggerProvider, T>();
            return builder;
        }
    }
