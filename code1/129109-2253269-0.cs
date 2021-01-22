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
    
        private void OnMyEvent()
        {
            if (MyEvent != null)
            {
                MyEvent(this, EventArgs.Empty);    
            }
        }
    }
