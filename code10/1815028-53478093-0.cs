    public class MessageUpdater
    {
        public event EventHandler<string> MessageSent;
        public void SendMessage(string message)
        {
            this.MessageSent?.Invoke(this, message);
        }
    }
