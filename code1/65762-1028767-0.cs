    using System;
    using System.IO;
    using log4net;
    using log4net.Config;
    namespace MyApplication.Logging
    {
        //// TODO: Implement the additional GetLogger method signatures and log4net.LogManager methods that are not seen below.
        public static class MyLogManager
        {
            private static readonly string LOG_CONFIG_FILE= @"path\to\log4net.config";
    
            public static void GetLogger(Type type)
            {
                // If no loggers have been created, load our own.
                if(log4net.LogManager.GetCurrentLoggers().Length == 0)
                {
                    LoadConfig();
                }
                return LogManager.GetLogger(type);
            }
            private void LoadConfig()
            {
               //// TODO: Do exception handling for File access issues and supply sane defaults if it's unavailable.   
               XmlConfigurator.ConfigureAndWatch(new FileInfo(LOG_CONFIG_FILE));
            }              
    }
