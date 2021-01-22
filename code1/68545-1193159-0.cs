    enum MessageType
    {
    Type1,Type2
    }
    private Dictionary<MessageType, TestHandlerWithInheritance> handlers;
    public void RegisterObserver(MessageType type, TestHandlerWithInheritance handler)
    {
      if(!handlers.ContainsKey(type))
      {
        handlers[key] = handler;
      }
      else
      {
        handlers[key] = Delegate.Combine(handlers[key] , handler);
      }
    }
