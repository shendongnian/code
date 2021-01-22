    public class BooleanValueChangedEventArgs : EventArgs
    {
        public bool NewValue;
    
        public BooleanValueChangedEventArgs(bool value)
            : base()
        {
            this.NewValue = value;
        }
    }
    
    public delegate void HandleBooleanValueChange(object sender, BooleanValueChangedEventArgs e);
