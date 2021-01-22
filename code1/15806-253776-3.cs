    public class A
    {
        public event EventHandler SomeEvent;
    
        public void someMethod()
        {
            OnSomeEventRaised();
        }
        protected void OnSomeEventRaised()
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
            OnSomeEventRaised();
        }
    }
