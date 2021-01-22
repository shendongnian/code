    public IMessage SyncProcessMessage(IMessage msg)
    {
          Type type = Type.GetType(msg.Properties["__TypeName"].ToString());
    
          object[] custom = type.GetMethod("Method").GetCustomAttributes(false);
          TimeoutAttribute ta = custom[0] as TimeoutAttribute;
          int time = ta.Ticks;
    
          IMessage returnedMessage = _nextSink.SyncProcessMessage(msg);
          return returnedMessage;
    }
              
