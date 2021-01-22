public void SomeMethodOrConstructor()
{
  AppServer.ReceiveRequest += ReceiveMessage;
}
public void ReceiveMessage(RemoteRequest rr)
{
  //handle the event here
}
