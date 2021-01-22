    // A delegate type for hooking up change notifications.
    public delegate void ChangedEventHandler(object sender, EventArgs e);
    
    class X
    {
        private double _inT;
        // An event that clients can use to be notified whenever the
        // elements of the list change.
        public event ChangedEventHandler InTChanged;
        // Invoke the Changed event; called whenever list changes
        
        protected virtual void OnChanged(EventArgs e) 
        {
            if (InTChanged != null)
                InTChanged(this, e);
        }
        public double InT
        {
            get { return InT; }
            set
            {
                _inT = newInT;
                
                //Invoke InTChanged event here
                OnChanged(EventArgs.Empty);
            }
        }
    }
