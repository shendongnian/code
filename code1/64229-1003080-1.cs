    abstract class MessageProcessor
    {
        public abstract void ProcessMessage(object source, object type);
    }
    class MessageProcessor<T> : MessageProcessor 
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
            Console.WriteLine(type.GetType());
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Type, MessageProcessor> messageProcessors = new Dictionary<Type, MessageProcessor>();
            messageProcessors.Add(typeof(string), new MessageProcessor<string>());
            string message = "";
            Type key = message.GetType();
            MessageProcessor processor = messageProcessors[key];
            processor.ProcessMessage(message, message);
        }
    }
