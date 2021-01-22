    using log4net;
    using log4net.Appender;
    using log4net.Repository;
    namespace MyNameSpace {
    public class MyClass {
        private static readonly ILog logger = LogManager.GetLogger(typeof(MyClass));
        public String GetLogFileName() {
            String filename = null;
            IAppender[] appenders = logger.Logger.Repository.GetAppenders();
            // Check each appender this logger has
            foreach (IAppender appender in appenders) {
                Type t = appender.GetType();
                // Get the file name from the first FileAppender found and return
                if (t.Equals(typeof(FileAppender)) || t.Equals(typeof(RollingFileAppender))) {
                    filename = ((FileAppender)appender).File;
                    break;
                }
            }
            return filename;
        }
    }
}
