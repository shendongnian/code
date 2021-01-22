    public class PropertyChangedEventArgsEx : PropertyChangedEventArgs
    {
        public object Sender { get; private set; }
        public PropertyChangedEventArgsEx(string propertyName, object sender) 
            : base(propertyName)
        {
            this.Sender = sender;
        }
    }
