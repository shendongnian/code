    abstract class MessageProcessor
    {
    }
    
    class MessageProcessor<T> : MessageProcessor
    {
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
        }
    }
