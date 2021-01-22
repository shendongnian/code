    public class MyListener : IMessageListener
    {
        public event EventHandler<MessageEventArgs> MessageReceived;
    
        public void MessageTransfer(IMessage m)
        {
            OnMessageReceived(new MessageEventArgs(m));
        }
    
        protected void OnMessageReceived(MessageEventArgs e)
        {
            EventHandler<MessageEventArgs> temp = MessageReceived;
            if (temp != null)
            {
                temp(this, e);
            }
        }
    }
