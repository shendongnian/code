    public class LoggingListener
    {
        private string logPathValue = String.Empty;
        [XmlAttribute("logPath")]
        public string LogPath
        {
            get { return logPathValue; }
            set
            {
                if(value == null) throw new ArgumentNullException();
                this.logPathValue = value;
            }
        }
    }
