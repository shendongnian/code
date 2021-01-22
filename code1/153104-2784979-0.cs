    public delegate void MessageAvailableEventHandler(object sender,
        MessageAvailableEventArgs e);
    public class MessageAvailableEventArgs : EventArgs
    {
        public MessageAvailableEventArgs(int messageSize) : base()
        {
            this.MessageSize = messageSize;
        }
        public int MessageSize { get; private set; }
    }
