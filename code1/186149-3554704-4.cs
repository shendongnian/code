    public class ValueChangingEventArgs : EventArgs
    {
        public int OldValue{get;private set;}
        public int NewValue{get;private set;}
        public bool Cancel{get;set;}
    
        public ValueChangingEventArgs(int OldValue, int NewValue)
        {
            this.OldValue = OldValue;
            this.NewValue = NewValue;
            this.Cancel = false;
        }
    }
    
