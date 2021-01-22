    class Message
    {
        public abstract void Process();
    }
    
    class SimpleMessage
    {
        public override void Process()
        {
            new SimpleMessageProcessor().Process();
        }
    }
    
    class SimpleMessageProcessor
    {
        internal void Process()
        {
            // ...
        }
    }
