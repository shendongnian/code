    public static class MessageDispatcher
    {
      private static readonly IMessageHandler s_DefaultHandler =
          new DefaultMessageHandler();
      private static readonly Dictionary<Type, IMessageHandler> s_Handlers =
          new Dictionary<Type, IMessageHandler>();
          
      static MessageDispatcher()
      {
        // Register a bunch of handlers.
        s_Handlers.Add(typeof(OrderMessage), new OrderMessageHandler());
        s_Handlers.Add(typeof(TradeMessage), new TradeMessageHandler());
      }
        
      public void Dispatch(IMessage msg)
      {
        Type key = msg.GetType();
        if (s_Handlers.ContainsKey(key))
        {
          // We found a specific handler! :)
          s_Handlers[key].Process(msg);
        }
        else
        {
          // We will have to resort to the default handler. :(
          s_DefaultHandler.Process(msg);
        }
      }
    }
        
    public interface IMessageHandler
    {
      void Process(IMessage msg);
    }
    
    public class OrderMessageHandler : IMessageHandler
    {
    }
    
    public class TradeMessageHandler : IMessageHandler
    {
    }
