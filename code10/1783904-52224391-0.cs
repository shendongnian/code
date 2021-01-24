    class SMAPIException
    {
        private SMAPIException( string message) : base(message)
        {
            // whatever initialization
        }
    
        public SMAPIException CreateSmapiException(string message)
        {
            string localizedErrMessage;
            // do whatever to set localizedErrMessage
    
            return SMAPIException(localizedErrMessage);
        }
    }
