    public class LoggingListener {
        private readonly string _logPath;
    
        public LoggingListener(string logPath) {
            _logPath = logPath ?? string.Empty;
        }
    
        public string LogPath {
            get { return _logPath; }
        }
    }
