    class Class12
    {
        public static void Main()
        {
            Message m = new Message(1, "Hello world");
            IMessageHandler msgHandler = Factory.GetMessageHandler(m.MessageType);
            msgHandler.HandleMessage(m);
    
            Message m2 = new Message(2, "Adios world");
            IMessageHandler msgHandler2 = Factory.GetMessageHandler(m2.MessageType);
            msgHandler2.HandleMessage(m2);
        }
    }
    public class Factory
    {
        public static IMessageHandler GetMessageHandler(int msgType)
        {
            IMessageHandler msgHandler = null;
            switch(msgType)
            {
                case 1: 
                    msgHandler = new MessageHandler1();
                    break;
                case 2: 
                    msgHandler = new MessageHandler2();
                    break;
                default: 
                    msgHandler = new MessageHandler1();
                    break;
            }
            return msgHandler;
        }
    }
    public class Message
    {
        public int MessageType { get; set; }
        public string AMessage { get; set; }
    
        public Message(int messageType, string message)
        {
            this.MessageType = messageType;
            this.AMessage = message;
        }
    }
    public interface IMessageHandler
    {
        void HandleMessage(Message m);
    }
    class MessageHandler1 : IMessageHandler
    {
        
        #region IMessageHandler Members
    
    
        public void HandleMessage(Message m)
        {
            string message = m.AMessage;
            Console.WriteLine(message);
        }
    
        #endregion
    }
    class MessageHandler2 : IMessageHandler
    {
    
        #region IMessageHandler Members
    
    
        public void HandleMessage(Message m)
        {
            string message = m.AMessage;
            Console.WriteLine("Hey there " + message);
        }
    
        #endregion
    }
