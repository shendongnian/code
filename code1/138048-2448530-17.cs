    // The delegate type. This one is in the library, in the System namespace
    public void Eventhandler(object sender, Eventargs args);  
    // your class
    class Foo  
    {
        public event EventHandler Changed;    // the Event
    
        protected virtual void OnChanged()    // the Trigger
        {
            // make a copy to be more thread-safe
            EventHandler handler = Changed;   
            if (handler != null)
            {
                // invoke the subscribed event-handler(s)
                handler(this, EventArgs.Empty);  
            }
        }
    }
