    public class A
    {
        public event EventHandler SomeEvent;
    
        public void someMethod()
        {
            RaiseSomeEvent();
        }
        protected void RaiseSomeEvent()
        {
            EventHandler handler = SomeEvent;
            if(handler != null)
                handler(this, someArgs);
        }
    }
    
    public class B : A
    {
        public void someOtherMethod()
        {
            RaiseSomeEvent();
        }
    }
