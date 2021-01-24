    public class YourEventArgs : EventArgs
    {
        public string Name {get;set;}
    
        public IAlsVariable Source {get;set;}
    
        // If you still need it.
        public string PropertyName {get;set;}
    }
