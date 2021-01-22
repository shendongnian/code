    // Declare how a method must look in order to be added to the event.
    public delegate void ValueChangedHandler(Int32 oldValue, Int32 newValue);
    public class Notifier
    {
       // The event that is raised when ChangeValue() changes the
       // private field value.
       public event ValueChangedHandler ValueChanged;
       // A method that modifies the private field value and
       // notifies observers with by the ValueChanged event.
       public void ChangeValue(Int32 newValue)
       {
          // Check if value must be changed
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
          // Check if we must notify anybody.
          if (this.ValueChanged != null)
          {
             // Call all methods added to this event.
             this.ValueChanged(oldValue, newValue);
          }
       }
    }
