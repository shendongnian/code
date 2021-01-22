    public class ChangeNotifier
    {
        private int num; // Local data
        
        public ChangeNotifier(int number) { this.num = int; } // Ctor to assign data
        public event EventHandler NumberChanged; // The event that can be subscribed to
        public int Number
        {
            get { return this.num; }
            set
            {
                if (this.num != value) // If the value has changed...
                {
                    // Assign the new value to private storage
                    this.num = value;
                    // And fire the event
                    if (this.NumberChanged != null)
                        this.NumberChanged(this, EventArgs.Empty);
                }
            }
        }
    }
