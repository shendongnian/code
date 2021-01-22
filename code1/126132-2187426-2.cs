    public class MyClass1
    {
        ...
       
        public event EventHandler<EventArgs> NotifyValidate;
        protected void RaiseNotifyValidate(EventArgs e)
        {
           if (NotifyValidate != null)
           {
              NotifyValidate(this, e);
           }
        }
    
        ...
    }
