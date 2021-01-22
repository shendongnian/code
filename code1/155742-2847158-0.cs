    // event args class for transmitting the message in the event
    public class MessageEventArgs : EventArgs
    {
        public IMessage Message { get; private set; }
    
        public MessageEventArgs(IMessage message)
        {
            Message = message;
        }
    }
