    public class MessageHandler /* , MessageOutInterface */
    {
        private readonly Queue<string> messages;
    
        public MessageHandler()
        {
            this.messages = new Queue<string>();
        }
    
        public void MessageOut(string message)
        {
            this.messages.Enqueue(message);
        }
    
        public IEnumerable<string> PendingMessages() 
        {
            string message;
            while (this.messages.Count > 0)
                yield return this.messages.Dequeue();
        }
    }
