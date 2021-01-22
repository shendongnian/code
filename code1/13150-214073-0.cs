    delegate void ProcessMessageDelegate(Message message)
    
    Dictionary<int, ProcessMessageDelegate> methods;
    
    void RegisterMethod( int messageType, ProcessMessageDelegate processMessage)
    {
      methods[messageType] = processMessage;
    }
    
    void ProcessMessage(int messageType, Message message)
    {
      if(methods.ContainsKey(messageType)
      {
        methods[messageType](message);
      }
    }
