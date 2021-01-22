    public class MyClass
    {
      private XMPPObjectType xmpp;
      public void Main()
      {
        xmpp.OnLogin += MyMethod;
      }
      private void MyMethod(object o)
      {
        xmpp.Send(new Message(new Jid(JID_RECEIVER), MessageType.chat, "Hello, how are you?"));
      }
    }
