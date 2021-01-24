    namespace MyProject.Logger {
    public partial class Log {
        private static readonly Log _instance = new Log();
        protected ILog monitoringLogger;
        protected static ILog debugLogger;
        private Log() {
            monitoringLogger = LogManager.GetLogger(System.Environment.MachineName);
            debugLogger = LogManager.GetLogger(System.Environment.MachineName);
        }
        public static void Debug(string message) {
            debugLogger.Debug(message);
        }
        public static void Debug(string message, Exception exception) {
            debugLogger.Debug(message, exception);
        }
        public static void Info(string message) {
            _instance.monitoringLogger.Info(message);
        }
    }
