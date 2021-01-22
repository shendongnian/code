    // the delegate type, from the library, in the System namespace
    public void Eventhandler(object sender, Eventargs args);  
    // your class
    class Foo  
    {
        public event EventHandler Changed;  // the event
    
        protected virtual void OnChanged()
        {
            EventHandler handler = Changed; // make a copy to be more thread-safe
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
