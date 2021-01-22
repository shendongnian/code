    public class MyClass
    {
        public event EventHandler<EventArgs> MyEvent; // the event
        // protected to allow subclasses to override what happens when event raised.
        protected virtual void OnMyEvent(object sender, EventArgs e)
        {
            // prevent race condition by copying reference locally
            EventHandler<EventArgs> localHandler = MyEvent;
            if (localHandler != null)
            {
                localHandler(sender, e);
            }
        }
        public void SomethingThatGeneratesEvent()
        {
            OnMyEvent(this, EventArgs.Empty);
        }
    }
