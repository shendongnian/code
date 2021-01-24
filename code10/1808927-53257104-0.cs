        //
    // Summary:
    //     Extends Microsoft.Extensions.Logging.ILoggerFactory with methods for configuring
    //     Seq logging.
    public static class SeqLoggerExtensions
    {
        //
        // Summary:
        //     Adds a Seq logger configured from the supplied configuration section.
        //
        // Parameters:
        //   loggerFactory:
        //     The logger factory.
        //
        //   configuration:
        //     A configuration section with details of the Seq server connection.
        //
        // Returns:
        //     A logger factory to allow further configuration.
        public static ILoggerFactory AddSeq(this ILoggerFactory loggerFactory, IConfigurationSection configuration);
        //
        // Summary:
        //     Adds a Seq logger.
        //
        // Parameters:
        //   loggerFactory:
        //     The logger factory.
        //
        //   serverUrl:
        //     The Seq server URL; the default is http://localhost:5341.
        //
        //   apiKey:
        //     A Seq API key to authenticate or tag messages from the logger.
        //
        //   minimumLevel:
        //     The level below which events will be suppressed (the default is Microsoft.Extensions.Logging.LogLevel.Information).
        //
        //   levelOverrides:
        //     A dictionary mapping logger name prefixes to minimum logging levels.
        //
        // Returns:
        //     A logger factory to allow further configuration.
        public static ILoggerFactory AddSeq(this ILoggerFactory loggerFactory, string serverUrl = "http://localhost:5341", string apiKey = null, LogLevel minimumLevel = LogLevel.Information, IDictionary<string, LogLevel> levelOverrides = null);
        //
        // Summary:
        //     Adds a Seq logger.
        //
        // Parameters:
        //   loggingBuilder:
        //     The logging builder.
        //
        //   serverUrl:
        //     The Seq server URL; the default is http://localhost:5341.
        //
        //   apiKey:
        //     A Seq API key to authenticate or tag messages from the logger.
        //
        // Returns:
        //     A logging builder to allow further configuration.
        public static ILoggingBuilder AddSeq(this ILoggingBuilder loggingBuilder, string serverUrl = "http://localhost:5341", string apiKey = null);
        //
        // Summary:
        //     Adds a Seq logger configured from the supplied configuration section.
        //
        // Parameters:
        //   loggingBuilder:
        //     The logging builder.
        //
        //   configuration:
        //     A configuration section with details of the Seq server connection.
        //
        // Returns:
        //     A logging builder to allow further configuration.
        public static ILoggingBuilder AddSeq(this ILoggingBuilder loggingBuilder, IConfigurationSection configuration);
    }
