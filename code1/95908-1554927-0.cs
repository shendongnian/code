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
        // Do something
        obj.MyEvent -= new EventHandler<EventArgs>(action);
    });
    
    obj.MyEvent += new EventHandler<EventArgs>(action);
