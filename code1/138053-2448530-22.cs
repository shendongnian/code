    class MyEventArgs : EventArgs
    {
        public string Info { get; set; }
    }
    class Foo  
    {
        public event EventHandler<MyEventArgs> Changed;    // the Event
        ...
        protected virtual void OnChanged(string info)      // the Trigger
        {
            EventHandler handler = Changed;   // make a copy to be more thread-safe
            if (handler != null)
            {
               var args = new MyEventArgs(){Info = info};  // this part will vary
               handler(this, args);  
            }
        }
    }
    class Bar
    {       
       void Foo_Changed(object sender, MyEventArgs args)  // the Handler
       {
           string s = args.Info;
           ...
       }
    }
    
