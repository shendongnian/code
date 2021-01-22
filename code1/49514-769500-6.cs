    // Declare how a method must look in order to be used as an event handler.
    public delegate void ValueChangedHandler(Notifier sender, Int32 oldValue, Int32 newValue);
    public class Notifier
    {
        // Constructor with an instance name.
        public Notifier(String name)
        {
            this.Name = name;
        }
        public String Name { get; private set; }
        // The event that is raised when ChangeValue() changes the
        // private field value.
        public event ValueChangedHandler ValueChanged;
        // A method that modifies the private field value and
        // notifies observers by raising the ValueChanged event.
        public void ChangeValue(Int32 newValue)
        {
            // Check if value really changes.
            if (this.value != newValue)
            {
                // Safe the old value.
                Int32 oldValue = this.value;
                // Change the value.
                this.value = newValue;
                // Raise the ValueChanged event.
                this.OnValueChanged(oldValue, newValue);
            }
        }
        private Int32 value = 0;
        // Raises the ValueChanged event.
        private void OnValueChanged(Int32 oldValue, Int32 newValue)
        {
            // Copy the event handlers - this is for thread safty to
            // avoid that somebody changes the handler to null after
            // we checked that it is not null but before we called
            // the handler.
            ValueChangedHandler valueChangedHandler = this.ValueChanged;
            // Check if we must notify anybody.
            if (valueChangedHandler != null)
            {
                // Call all methods added to this event.
                valueChangedHandler(this, oldValue, newValue);
            }
        }
    }
