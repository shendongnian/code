    using System;
    delegate void MyEventHandler();
    class MyEvent
    {
    string s;
    public event MyEventHandler SomeEvent;
    // This is called to raise the event.
    public void OnSomeEvent()
    {
        if (SomeEvent != null)
        {
            SomeEvent();
        }
    }
    public string IsNull
    {
        get
        {
            if (SomeEvent != null)
                 return s = "The EventHandlerList is not NULL";
            else return s = "The EventHandlerList is NULL"; ;
        }
    }
    }
     class EventDemo
       {
      // An event handler.
     static void Handler()
     {
        Console.WriteLine("Event occurred");
       }
       static void Main()
     {
        MyEvent evt = new MyEvent();
        // Add Handler() to the event list.
        evt.SomeEvent += Handler;
        // Raise the event.
        //evt.OnSomeEvent();
        evt.SomeEvent -= Handler;
        Console.WriteLine(evt.IsNull);
        Console.ReadKey();
    }
}
