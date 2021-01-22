    public class MyClass
    {
      private event EventHandler _myEvent;
      public ExternalObject { get; set; }
    
      public event EventHandler MyEvent
      {
        add
        {
          if (_myEvent.GetInvocationList().Length == 0 && value != null)
            ExternalObject.ExternalEvent += HandleEvent;
          _myEvent+= value;
        }
        remove
        {
          _myEvent-= value;
          if (_myEvent.GetInvocationList().Length == 0)
            ExternalObject.ExternalEvent -= HandleEvent;
        }
      }
      private void HandleEvent(object sender, EventArgs e)
      {
         _myEvent.Raise(this, EventArgs.Empty); // raises the event.
      }
    }
