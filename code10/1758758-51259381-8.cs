    public class CustomerInfo
    {
        private Func<string, string> _loadLogbook;
        private string _logbookContent;
        ...
        public void SetLoadLogbook(Func<string, string> loadLogbook) => _loadLogbook = loadLogbook;
        ...
        public string Logbook { get; set; }
        public string LogbookContent
        {
            get
            {
                if(_logbookContent == null)
                {
                    _logbookContent = _loadLogbook?.Invoke(Logbook);
                }
                return _logbookContent;
            }
            set => _logbookContent = value;
        }
        ...
    }
