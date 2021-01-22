    public class MessageBoxEventArgs : EventArgs
    {
        public MessageBoxEventArgs(string message)
        {
            this.Message = message;
        }
        public string Message
        {
            get; private set;
        }
    }
