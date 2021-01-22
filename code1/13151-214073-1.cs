      delegate void ProcessMessageDelegate(Message message)
    
      public class MyMessageProcessor
      {
        Dictionary<int, ProcessMessageDelegate> methods;
        
        public void Register( int messageType, 
                              ProcessMessageDelegate processMessage)
        {
          methods[messageType] = processMessage;
        }
        
        public void ProcessMessage(int messageType, Message message)
        {
          if(methods.ContainsKey(messageType)
          {
            methods[messageType](message);
          }
        }
      }
