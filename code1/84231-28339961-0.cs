            String filename = null;
            Hierarchy hierarchy = LogManager.GetRepository() as Hierarchy;
            Logger logger = hierarchy.Root;
            IAppender[] appenders = logger.Repository.GetAppenders();
            // Check each appender this logger has
            foreach (IAppender appender in appenders)
            {
                Type t = appender.GetType();
                // Get the file name from the first FileAppender found and return
                if (t.Equals(typeof(FileAppender)) || t.Equals(typeof(RollingFileAppender)))
                {
                    filename = ((FileAppender)appender).File;
                    break;
                }
            }
            System.Diagnostics.Process.Start(filename); //for example, open file in notepad
