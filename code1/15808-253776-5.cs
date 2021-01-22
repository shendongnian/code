    public class A
    {
        public event EventHandler SomeEvent;
    
        public void someMethod()
        {
            OnSomeEvent();
        }
        protected void OnSomeEvent()
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
            OnSomeEvent();
        }
    }
