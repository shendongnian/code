    public class EventTest
    {
      private event EventHandler MyEvent = delegate { Console.WriteLine("Hello World"); }
    
      public void Test()
      {
        MyEvent(this, new EventArgs());
      }
    }
