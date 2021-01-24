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
            var myEvent =  target.MyEvent;
            myEvent?.Invoke(EventArgs.Empty, EventArgs.Empty);      
            target.AnotherEvent(null, null); 
        }
