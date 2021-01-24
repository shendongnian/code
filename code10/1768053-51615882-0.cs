    public interface IMessageLogic 
    {
       void ProcessMessage()
    }
    public class TriggerSignal : IMessageLogic 
    {
       public void ProcessMessage() 
       {
           // Do trigger stuff
       }
    }
    public class FooMessage : IMessageLogic 
    {
       public void ProcessMessage() 
       {
           // Do foo stuff
       }
    }
    public class MessageHandler
    {
        public void HandleMessage(IMessageLogic messageLogic)
        {
            messageLogic.ProcessMessage();
        }
    }
    public static void Main()
    {
        IMessageLogic messageLogic = GetMessage();
        var handler = new MessageHandler();
        
        handler.HandleMessage(messageLogic);
     }
