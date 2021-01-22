    public class LoggingListener : ILogListenerSettings
    {
        private string logPathValue;
        [XmlAttribute("logPath")]
        public string LogPath
        {
            get { return logPathValue; }
            set { logPathValue = value; }
        }
        string ILogListenerSettings.FullLogPath
        {
            get
            {
                string path = logPathValue;
                if(String.IsNullOrEmpty(path))
                    path = Environment.CurrentDirectory;
                path = Path.GetFullPath(path);
                Directory.Create(path);
                return path;
            }
        }
    }
