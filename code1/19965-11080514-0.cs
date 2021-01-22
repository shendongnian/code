    using System;
    using Com.Foo;
    using System.Collections.Generic;
    using System.Text;
    using log4net.Config;
    using log4net;
    using log4net.Appender;
    using log4net.Layout;
    using log4net.Repository.Hierarchy;
    
    
    public class MyApp
    {
    
    
        public static void SetLevel(string loggerName, string levelName)
        {
            ILog log = LogManager.GetLogger(loggerName);
            Logger l = (Logger)log.Logger;
            
            l.Level = l.Hierarchy.LevelMap[levelName];
        }
    
        // Add an appender to a logger
        public static void AddAppender(string loggerName, IAppender appender)
        {
            ILog log = LogManager.GetLogger(loggerName);
            Logger l = (Logger)log.Logger;
    
            l.AddAppender(appender);
        }
        // Add an appender to a logger
        public static void AddAppender2(ILog log, IAppender appender)
        {
           // ILog log = LogManager.GetLogger(loggerName);
            Logger l = (Logger)log.Logger;
    
            l.AddAppender(appender);
        }
    
        // Create a new file appender
        public static IAppender CreateFileAppender(string name, string fileName)
        {
            FileAppender appender = new
                FileAppender();
            appender.Name = name;
            appender.File = fileName;
            appender.AppendToFile = true;
    
            PatternLayout layout = new PatternLayout();
            layout.ConversionPattern = "%d [%t] %-5p %c [%logger] - %m%n";
            layout.ActivateOptions();
    
            appender.Layout = layout;
            appender.ActivateOptions();
    
            return appender;
        }
    
        private static readonly ILog log = LogManager.GetLogger(typeof(MyApp));
        static void Main(string[] args)
        {
            BasicConfigurator.Configure();
            SetLevel("Log4net.MainForm", "ALL");
            AddAppender2(log, CreateFileAppender("appenderName", "fileName.log"));
            log.Info("Entering application.");
            Console.WriteLine("starting.........");
            log.Info("Entering application.");
            Bar bar = new Bar();
            bar.DoIt();
            Console.WriteLine("starting.........");
            log.Error("Exiting application.");
            Console.WriteLine("starting.........");
        }
    }
    
    
    namespace Com.Foo
    {
        public class Bar
        {
            private static readonly ILog log = LogManager.GetLogger(typeof(Bar));
    
            public void DoIt()
            {
                log.Debug("Did it again!");
            }
        }
    }
