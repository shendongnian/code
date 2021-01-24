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
            while ((message = this.messages.Dequeue()) != null)
                yield return message;
        }
    }
