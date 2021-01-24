    public static ILoggerFactory AddLog4Net(this ILoggerFactory factory, string log4NetConfigFile, bool watch)
    {
        factory.AddProvider(new Log4NetProvider(log4NetConfigFile, watch));
        return factory;
    }
