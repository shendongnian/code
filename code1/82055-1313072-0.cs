    class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.BasicConfigurator.Configure();
            var file = Path.Combine(Directory.GetCurrentDirectory(), Guid.NewGuid() + ".log");
            using (var log = new CustomFileLogger(file))
            {
                // Process file...
                log.Info("file: Made it here!");
                log.Error("file: Made it here!");
            }
            var file2 = Path.Combine(Directory.GetCurrentDirectory(), Guid.NewGuid() + ".log");
            using (var log = new CustomFileLogger(file2))
            {
                // Process file...
                log.Info("file2: Made it here!");
                log.Error("file2: Made it here!");
            }
        }
    }
    public sealed class CustomFileLogger : ILog, IDisposable
    {
        private ILog _log;
        private FileAppender _appender;
        private string _file;
        public CustomFileLogger(string file)
        {
            _file = file;
            var hierarchy = (Hierarchy)LogManager.GetRepository();
            hierarchy.Configured = false;
            var patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = "%d [%t] %-5p %c [%x] - %m%n";
            patternLayout.ActivateOptions();
            var appender = new FileAppender { File = file, AppendToFile = true, Layout = patternLayout };
            appender.ActivateOptions();
            var logger = (Logger)hierarchy.GetLogger(file);
            logger.AddAppender(appender);
            hierarchy.Configured = true;
            _log = LogManager.GetLogger(file);
        }
        public ILogger Logger
        {
            get { return _log.Logger; }
        }
        public void Dispose()
        {
            var hierarchy = (Hierarchy)LogManager.GetRepository();
            hierarchy.Configured = false;
            var logger = (Logger)hierarchy.GetLogger(_file);
            logger.RemoveAppender(_appender);
            hierarchy.Configured = false;
            _appender = null;
            _log = null;
            _file = null;
        }
        public void Debug(object message)
        {
            _log.Debug(message);
        }
        public void Debug(object message, Exception exception)
        {
            _log.Debug(message, exception);
        }
        public void DebugFormat(string format, params object[] args)
        {
            _log.DebugFormat(format, args);
        }
        public void DebugFormat(string format, object arg0)
        {
            _log.DebugFormat(format, arg0);
        }
        public void DebugFormat(string format, object arg0, object arg1)
        {
            _log.DebugFormat(format, arg0, arg1);
        }
        public void DebugFormat(string format, object arg0, object arg1, object arg2)
        {
            _log.DebugFormat(format, arg0, arg1, arg2);
        }
        public void DebugFormat(IFormatProvider provider, string format, params object[] args)
        {
            _log.DebugFormat(provider, format, args);
        }
        public void Info(object message)
        {
            _log.Info(message);
        }
        public void Info(object message, Exception exception)
        {
            _log.Info(message, exception);
        }
        public void InfoFormat(string format, params object[] args)
        {
            _log.InfoFormat(format, args);
        }
        public void InfoFormat(string format, object arg0)
        {
            _log.InfoFormat(format, arg0);
        }
        public void InfoFormat(string format, object arg0, object arg1)
        {
            _log.InfoFormat(format, arg0, arg1);
        }
        public void InfoFormat(string format, object arg0, object arg1, object arg2)
        {
            _log.InfoFormat(format, arg0, arg1, arg2);
        }
        public void InfoFormat(IFormatProvider provider, string format, params object[] args)
        {
            _log.InfoFormat(provider, format, args);
        }
        public void Warn(object message)
        {
            _log.Warn(message);
        }
        public void Warn(object message, Exception exception)
        {
            _log.Warn(message, exception);
        }
        public void WarnFormat(string format, params object[] args)
        {
            _log.WarnFormat(format, args);
        }
        public void WarnFormat(string format, object arg0)
        {
            _log.WarnFormat(format, arg0);
        }
        public void WarnFormat(string format, object arg0, object arg1)
        {
            _log.WarnFormat(format, arg0, arg1);
        }
        public void WarnFormat(string format, object arg0, object arg1, object arg2)
        {
            _log.WarnFormat(format, arg0, arg1, arg2);
        }
        public void WarnFormat(IFormatProvider provider, string format, params object[] args)
        {
            _log.WarnFormat(provider, format, args);
        }
        public void Error(object message)
        {
            _log.Error(message);
        }
        public void Error(object message, Exception exception)
        {
            _log.Error(message, exception);
        }
        public void ErrorFormat(string format, params object[] args)
        {
            _log.ErrorFormat(format, args);
        }
        public void ErrorFormat(string format, object arg0)
        {
            _log.ErrorFormat(format, arg0);
        }
        public void ErrorFormat(string format, object arg0, object arg1)
        {
            _log.ErrorFormat(format, arg0, arg1);
        }
        public void ErrorFormat(string format, object arg0, object arg1, object arg2)
        {
            _log.ErrorFormat(format, arg0, arg1, arg2);
        }
        public void ErrorFormat(IFormatProvider provider, string format, params object[] args)
        {
            _log.ErrorFormat(provider, format, args);
        }
        public void Fatal(object message)
        {
            _log.Fatal(message);
        }
        public void Fatal(object message, Exception exception)
        {
            _log.Fatal(message, exception);
        }
        public void FatalFormat(string format, params object[] args)
        {
            _log.FatalFormat(format, args);
        }
        public void FatalFormat(string format, object arg0)
        {
            _log.FatalFormat(format, arg0);
        }
        public void FatalFormat(string format, object arg0, object arg1)
        {
            _log.FatalFormat(format, arg0, arg1);
        }
        public void FatalFormat(string format, object arg0, object arg1, object arg2)
        {
            _log.FatalFormat(format, arg0, arg1, arg2);
        }
        public void FatalFormat(IFormatProvider provider, string format, params object[] args)
        {
            _log.FatalFormat(provider, format, args);
        }
        public bool IsDebugEnabled
        {
            get { return _log.IsDebugEnabled; }
        }
        public bool IsInfoEnabled
        {
            get { return _log.IsInfoEnabled; }
        }
        public bool IsWarnEnabled
        {
            get { return _log.IsWarnEnabled; }
        }
        public bool IsErrorEnabled
        {
            get { return _log.IsErrorEnabled; }
        }
        public bool IsFatalEnabled
        {
            get { return _log.IsFatalEnabled; }
        }
    }
