    public class MyClassWithEvents
        {
            public event EventHandler MyEvent;
        
            protected void OnMyEvent(object sender, EventArgs eventArgs)
            {
                if (MyEvent != null)
                {
                    MyEvent(sender, eventArgs);
                }
            }
        
            public void TriggerMyEvent()
            {
                OnMyEvent(sender, eventArgs);
            }
        }
    
