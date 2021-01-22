    public static class LogFactory
    {
        public const string DefaultConfigFileName = "log4net.config";
        
        static ILog GetLogger(Type callingType)
        {
            return new Log4NetLogger(LogManager.GetLogger(callingType));
        }
        public static void Configure()
        {
            Type type = typeof(LogFactory);
            FileInfo assemblyDirectory = AssemblyInfo.GetCodeBaseDirectory(type);
            FileInfo configFile = new FileInfo(Path.Combine(assemblyDirectory.FullName,
                DefaultConfigFileName));
            XmlConfigurator.ConfigureAndWatch(configFile);
            log4net.ILog log = LogManager.GetLogger(type);
            log.ToString();
        }
    }
