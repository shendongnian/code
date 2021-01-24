     private EventHandler myEvent;
     public event EventHandler MyEvent
        {
            add
            {
                lock (objectLock)
                {
                    myEvent += value;
                }
            }
            remove
            {
                lock (objectLock)
                {
                    myEvent -= value;
                }
            }
        }
    
        public event EventHandler AnotherEvent;
    
        public static void Main()
        {
            var target = new Program();
            target.MyEvent(EventArgs.Empty, EventArgs.Empty);       // ERROR CS0079
            target.AnotherEvent(null, null);  // compiles
        }
