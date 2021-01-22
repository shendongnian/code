    public abstract class DefaultMessageHandler<T> : IMessageHandler<T> where T : struct {
        public delegate void MessageHandlerDelegate(IMessage<T> message, IConnection connnection);
        private readonly IDictionary<T, MessageHandlerDelegate> messageHandlerDictionary = 
            new Dictionary<T, MessageHandlerDelegate>();
        protected void RegisterMessageHandler(T messageType, MessageHandlerDelegate handler) {
            if (this.messageHandlerDictionary.ContainsKey(messageType)) 
                return;
            else this.messageHandlerDictionary.Add(messageType, handler);
        }
        protected void UnregisterMessageHandler(T messageType) {
            if (this.messageHandlerDictionary.ContainsKey(messageType))
                this.messageHandlerDictionary.Remove(messageType);
        }
        protected virtual void HandleUnregisteredMessage(IMessage<T> message, IConnection connection) {
        }
        void IMessageHandler<T>.HandleMessage(IMessage<T> message, IConnection connection) {
            if (this.messageHandlerDictionary.ContainsKey(message.MessageType))
                this.messageHandlerDictionary[message.MessageType].Invoke(message, connection);
            else HandleUnregisteredMessage(message, connection);
        }
    }
