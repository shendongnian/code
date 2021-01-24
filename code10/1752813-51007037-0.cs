    private Dicitionary<string, INetworkObject> Registrations;
    
    public void Register(INetworkObject o)
    {
      Registrations[o.ShatNetIdentity] = o;
    }
    
    private void ReceiveMessage()
    {
      // receive and parse message.
      if ( Registrations.TryGet(message.Id, out INetworkObject o )
      {
        switch (message.messageType)
        {
          case MessageType.Health: 
          o.Health = message.Health;
          break;
          // etc..
        }
      }
    }
