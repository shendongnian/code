delegate void OnLoginEventHandler(object o);
public void MyLoginEventHandler(object o)
{
      xmpp.Send(
         new Message(new Jid(JID_RECEIVER), MessageType.chat, "Hello, how are you?")); 
}
[...]
xmpp.OnLogin += new OnLoginEventHandler(MyLoginEventHandler);
