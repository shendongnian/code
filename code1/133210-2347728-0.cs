    public enum Message
    {
      Connect,
      Disconnect
    }
    public void Action(Message msg)
    {
       switch(msg)
       {
          case Message.Connect: 
             //do connect here
           break;
          case Message.Disconnect: 
              //disconnect
           break;
          default:
              //Fail!
           break;
       }
    }
