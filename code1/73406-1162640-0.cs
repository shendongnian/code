    using WCF.ServiceClientReference; // Contains WCF service reference and related data contracts
    
    class ServiceFacade
    {
        private ServiceClient m_client;
    
        void SendMessage(ClientMessage message)
        {
            Message serviceMessage = new Message
            {
                Subject = message.Subject,
                MessageBodies = new CommMessageBodies(message.MessageBodies.Select(b => new CommMessageBody(b))
            }
    
            m_client.SendMessage(serviceMessage);
        }
    }
    
    class ClientMessage
    {
        public ClientMessage()
        {
            MessageBodies = new List<ClientMessageBody>();
        }
    
        public string Subject {get; }
        public IList<ClientMessageBody> MessageBodies { get; private set; } 
    }
    
    // etc.
