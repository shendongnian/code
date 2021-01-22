    public class Foo
    {
        public EventHandler<EventArgs> MyEvent;
        public void FireEvent()
        {
            if(MyEvent != null)
                MyEvent(this, EventArgs.Empty);
        }
    }
    Foo obj = new Foo();
    
    Action<object, EventArgs> action = new Action<object, EventArgs>((sender, args) =>
    {
        // We're now running the event handler, so unsubscribe
        obj.MyEvent -= new EventHandler<EventArgs>(action);
        // Do whatever you wanted to do when the event fired.
    });
    
    obj.MyEvent += new EventHandler<EventArgs>(action);
