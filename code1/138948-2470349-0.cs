    class AppSpecificException : ApplicationException
    {
        public string SpecificTrace { get; private set; }
        public string SpecificMessage { get; private set; }
        public AppSpecificException(string message, Exception innerException)
        {
            SpecificMessage = message;
            SpecificTrace = innerException.StackTrace;
        }
        
    }
