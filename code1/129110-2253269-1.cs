    public class A
    {
        private readonly B _B = new B();
    
        public class A() 
        {
            _B.MyEvent += MyEventHandler; 
        }
    
        private void MyEventHandler(object sender, EventArgs e)
        {
            // Handle
        }
    }
    
    public class B
    {
        public event EventHandler MyEvent;
    
        // Call this when you raise the event so you don't 
        // need check if MyEvent is null.
        private void OnMyEvent() 
        {
            if (MyEvent != null) // If this is null we have no subscribers.
            {
                MyEvent(this, EventArgs.Empty);    
            }
        }
    }
