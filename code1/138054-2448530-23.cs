    // The delegate type. This one is already defined in the library, in the System namespace
    public delegate void Eventhandler(object sender, Eventargs args);  
    // your class
    class Foo  
    {
        public event EventHandler Changed;    // the Event
    
        protected virtual void OnChanged()    // the Trigger. Foo calls this to raise the event
        {
            // make a copy to be more thread-safe
            EventHandler handler = Changed;   
            if (handler != null)
            {
                // invoke the subscribed event-handler(s)
                handler(this, EventArgs.Empty);  
            }
        }
        void SomeMethod()
        {
           if (...)        // on some condition
             OnChanged();  // raise the event
        }
    }
