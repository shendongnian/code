    public interface IMessageHandler {
        bool HandleMessage( IMessage msg );
    }
    
    public class OrderMessageHandler {
        bool HandleMessage( IMessage msg ) {
           if ( !msg is OrderMessage) return false;
    
           // Handle the message.
        }
    }
    
    public class SomeOtherMessageHandler {
        bool HandleMessage( IMessage msg ) {
           if ( !msg is SomeOtherMessage ) return false;
     
           // Handle the message.
        }
    }
    
    ... etc ...
    
    public class MessageProcessor {
        private List<IMessageHandler> handlers;
    
        public MessageProcessor() {
           handlers = new List<IMessageHandler>();
           handlers.add(new SomeOtherMessageHandler());
           handlers.add(new OrderMessageHandler());
        }
    
        public void ProcessMessage( IMessage msg ) {
           bool messageWasHandled
           foreach( IMessageHandler handler in handlers ) {
               if ( handler.HandleMessage(msg) ) {
                   messageWasHandled = true;
                   break;
               }
           }
           if ( !messageWasHandled ) {
              // Do some default processing, throw error, whatever.
           }
        }
    }
