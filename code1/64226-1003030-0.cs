     public abstract class Message { 
         // ...
     }
     public class Message<T> : Message {
     }
     
     public abstract class MessageProcessor {
         public abstract void ProcessMessage(Message msg);
     }
     public class SayMessageProcessor : MessageProcessor {
         public override void ProcessMessage(Message msg) {
             ProcessMessage((Message<Say>)msg);
         }
         public void ProcessMessage(Message<Say> msg) {
             // do the actual processing
         }
     }
     // Dispatcher logic:
     Dictionary<Type, MessageProcessor> messageProcessors = {
        { typeof(Say), new SayMessageProcessor() },
        { typeof(string), new StringMessageProcessor() }
     }; // properly initialized
     messageProcessors[msg.GetType().GetGenericArguments()[0]].ProcessMessage(msg);
