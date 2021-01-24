    public class MessageManager : IMessageManager
    {
        private List<string> _successMessages = new List<string>();
        private List<string> _errorMessages = new List<string>();
        private List<string> _warningMessage = new List<string>();
        private List<string> _infoMessage = new List<string>();
        public void AddSuccess(string message)
        {
            _successMessages.Add(message);
        }
        public void AddError(string message)
        {
            _errorMessages.Add(message);
        }
        public void AddWarning(string message)
        {
            _warningMessages.Add(message);
        }
        public void AddInfo(string message)
        {
            _infoMessages.Add(message);
        }
        public List<string> SuccessMessages
        {
            get { return _successMessages; }
        }
       
        public List<string> ErrorMessages
        {
            get { return _errorMessages; }
        }
        public List<string> WarningMessages
        {
            get { return _warningMessages; }
        }
        public List<string> InfoMessages
        {
            get { return _infoMessages; }
        }
    }
