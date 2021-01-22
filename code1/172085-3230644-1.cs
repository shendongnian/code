    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Reflection;
    
    namespace SO
    {
        class Program
        {
            static void Main(string[] args)
            {
                MessageFactory factory = new MessageFactory();
    
                IMessage msg = factory.CreateObject(1);
                IMessage msg2 = factory.CreateObject(2);
            }
        }
    
        public interface IMessage
        {
            short Message_ID { get; }
        } 
    
        public class Generic_Message1 : IMessage 
        { 
            public short Message_ID { get { return ID; } } 
            internal const short ID = 1; 
        } 
    
        public class center_message1 : IMessage 
        { 
            public short Message_ID { get { return ID; } } 
            internal const short ID = 2; 
        } 
    
        public class MessageFactory
        {
            private Dictionary<short, Type> messageMap = new Dictionary<short, Type>();
    
            public MessageFactory()
            {
                Type[] messageTypes = Assembly.GetAssembly(typeof(IMessage)).GetTypes();
                foreach (Type messageType in messageTypes)
                {
                    if (!typeof(IMessage).IsAssignableFrom(messageType) || messageType == typeof(IMessage))
                    {
                        // messageType is not derived from IMessage   
                        continue;
                    }
    
                    IMessage message = (IMessage)Activator.CreateInstance(messageType);               
                    messageMap.Add(message.Message_ID, messageType);
                }
            }
    
            public IMessage CreateObject(short Message_ID, params object[] args)
            {
                return (IMessage)Activator.CreateInstance(messageMap[Message_ID], args);
            }
        } 
    
    }
