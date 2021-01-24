        private string _logDetails;
        public string LogLevelDetails
        {
            get
            {
                return _logDetails;
            }
            set
            {
                if (_logDetails == value)
                {
                    _logDetails = value;
                    RaisePropertyChanged(nameof(LogLevelDetails));
                }
            }
        }
        private LogLevel _logLevel;
        public LogLevel LogLevel
        {
            get
            {
                return _logLevel;
            }
            set
            {
                if (_logLevel == value)
                {
                    _logLevel = value;
                    RaisePropertyChanged(nameof(LogLevel));
                }
            }
        }
