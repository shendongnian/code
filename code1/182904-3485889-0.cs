    public class MyClass
    {
        private SynchronizationContext synchronizationContext = WindowsFormsSynchronizationContext.Current;
    
        public void SomethingToCauseEvent()
        {
            OnMyEvent(EventArgs.Empty);
        }
    
        public event EventHandler MyEvent;
    
        protected void OnMyEvent(EventArgs e)
        {
            if (MyEvent != null)
            {
                synchronizationContext.Post(new SendOrPostCallback(OnMyEventInternal), e);
            }
        }
    
        private void OnMyEventInternal(object state)
        {
            MyEvent(this, state as EventArgs);
        }
    }
