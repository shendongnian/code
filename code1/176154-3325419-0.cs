public class AnEvent
{
  public delegate MyReturnType MyDelegateName();
  public event MyDelegateName MyEvent;
  public void DoStuff()
  {
    MyReturnType result = null;
    if (MyEvent != null)
      result = MyEvent();
    Console.WriteLine("the event was fired");
    if (result != null)
      Console.Writeline("the result is" + result.ToString());
  }
}
public class EventListener
{
  public EventListener()
  {
    var anEvent = new AnEvent();
    anEvent.MyEvent += SomeMethod;
  }
  public MyReturnType SomeMethod()
  {
    Console.Writeline("the event was handled!");
    return new MyReturnType;
  }
}
