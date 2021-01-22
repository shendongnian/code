    public class ChangeNotifier
    {
        // Local data
        private int num; 
        
        // Ctor to assign data
        public ChangeNotifier(int number) { this.num = number; } 
         // The event that can be subscribed to
        public event EventHandler NumberChanged;
        public int Number
        {
            get { return this.num; }
            set
            {
                // If the value has changed...
                if (this.num != value) 
                {
                    // Assign the new value to private storage
                    this.num = value;
                    // And raise the event
                    if (this.NumberChanged != null)
                        this.NumberChanged(this, EventArgs.Empty);
                }
            }
        }
    }
