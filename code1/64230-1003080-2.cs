    interface IMessage
    {
        void Process(object source);
    }
    class LoginMessage : IMessage
    {
        public void Process(object source)
        {
        }
    }
    abstract class MessageProcessor
    {
        public abstract void ProcessMessage(object source, object type);
    }
    class MessageProcessor<T> : MessageProcessor where T: IMessage
    {
        public override void ProcessMessage(object source, object o) 
        {
            if (!(o is T)) {
                throw new NotImplementedException();
            }
            ProcessMessage(source, (T)o);
        }
        public void ProcessMessage(object source, T type)
        {
            type.Process(source);
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Type, MessageProcessor> messageProcessors = new Dictionary<Type, MessageProcessor>();
            messageProcessors.Add(typeof(string), new MessageProcessor<LoginMessage>());
            LoginMessage message = new LoginMessage();
            Type key = message.GetType();
            MessageProcessor processor = messageProcessors[key];
            object source = null;
            processor.ProcessMessage(source, message);
        }
    }
