    static void Main(string[] args)
    {
        const string logLayoutPattern =
            "[%date %timestamp][%level] %message %newline" +
            "Domain: %appdomain, User: %username %identity %newline" +
            "%stacktracedetail{10} %newline" +
            "%exception %newline";
        var wrapperLogger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        var logger = (Logger) wrapperLogger.Logger;
        logger.Hierarchy.Root.Level = Level.All;
        var consoleAppender = new ConsoleAppender
        {
            Name = "ConsoleAppender",
            Layout = new PatternLayout(logLayoutPattern)
        };
        logger.Hierarchy.Root.AddAppender(consoleAppender);
        logger.Hierarchy.Configured = true;
        wrapperLogger.Debug("Hello");
        Console.ReadKey();
    }
