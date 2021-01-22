    public interface INotifyProperyChanged<T>
    {
       event PropertyChangedEventHandler<T> PropertyChanged;
    }
    
        public delegate void PropertyChangedEventHandler<T>(object sender,   
    PropertyChangedEventArgs<T> e);
        
    public class PropertyChangedEventArgs<T> : EventArgs
    {
        private readonly string propertyName;
     
        public PropertyChangedEventArgs(string propertyName)
        {
            this.propertyName = propertyName
        }
        
        public virtual string PropertyName { get { return propertyName; } }
      
        public T OldValue { get; set; }
        public T NewValue { get; set; }
    }
