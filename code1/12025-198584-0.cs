     public event EventHandler<EventArgs> MyEventToBeFired;
        public void FireEvent(Guid instanceId, string handler)
        {
            // Note: this is being fired from a method with in the same class that defined the event (i.e. "this").
            EventArgs e = new EventArgs(instanceId); 
            MulticastDelegate eventDelagate =
                  (MulticastDelegate)this.GetType().GetField(handler,
                   System.Reflection.BindingFlags.Instance |
                   System.Reflection.BindingFlags.NonPublic).GetValue(this); 
            Delegate[] delegates = eventDelagate.GetInvocationList();
            foreach (Delegate dlg in delegates)
            {
                dlg.Method.Invoke(dlg.Target, new object[] { this, e }); 
            }
        }
        FireEvent(new Guid(),  "MyEventToBeFired"); 
