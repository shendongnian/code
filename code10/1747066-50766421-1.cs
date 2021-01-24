    void Main()
    {
        var obj = new TestObject();
    
        obj.Event1 += (sender, e) => Handler("Event 1");
        obj.Event1 += (sender, e) => Handler("Event 1");
    
        obj.Event2 += (sender, e) => Handler("Event 2");
        obj.Event2 += (sender, e) => Handler("Event 2");
    
        obj.Event3 += (sender, e) => Handler("Event 3");
        obj.Event3 += (sender, e) => Handler("Event 3");
    
        Debug.WriteLine("Prove events are attached");
        obj.RaiseEvents();
    
        var events = new SuspendedEvents(obj);    
        Debug.WriteLine("Prove events are detached");
        obj.RaiseEvents();
    
        events.Restore();
        Debug.WriteLine("Prove events are reattached");
        obj.RaiseEvents();
    }
    public void Handler(string message)
    {
        Debug.WriteLine(message);
    }
    public class TestObject
    {
        public event EventHandler<EventArgs> Event1;
        public event EventHandler<EventArgs> Event2;
        public event EventHandler<EventArgs> Event3;
    
        public void RaiseEvents()
        {
            Event1?.Invoke(this, EventArgs.Empty);
            Event2?.Invoke(this, EventArgs.Empty);
            Event3?.Invoke(this, EventArgs.Empty);
        }
    }
