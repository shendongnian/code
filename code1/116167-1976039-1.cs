    public static class EmailDispatcher
    {
        public event EmailSentEventHandler EmailSent
        {
            add    { _implementation.EmailSent += value; }
            remove { _implementation.EmailSent -= value; }
        }
    
        public event EmailFailedEventHandler EmailFailed
        {
            add    { _implementation.EmailFailed += value; }
            remove { _implementation.EmailFailed -= value; }
        }
    }
