    public class MessageHandler /* , MessageOutInterface */
    {
        private readonly object syncRoot = new Object();
        private readonly Queue<string> messages;
    
        public MessageHandler()
        {
            this.messages = new Queue<string>();
        }
    
        public void MessageOut(string message)
        {
            lock (this.syncRoot)
            {
                this.messages.Enqueue(message);
            }
        }
    
        public IEnumerable<string> PendingMessages() 
        {
            lock (this.syncRoot)
            {
                var pending = this.messages.ToArray();
                this.messages.Clear();
                return pending;
            }
        }
    }
