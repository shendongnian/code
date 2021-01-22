    public abstract class BaseModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Initializes a new instance of the BaseModel class.
        /// </summary>
        protected BaseModel()
        {
        }
    
        /// <summary>
        /// Fired when a property in this class changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
    
        /// <summary>
        /// Triggers the property changed event for a specific property.
        /// </summary>
        /// <param name="propertyName">The name of the property that has changed.</param>
        public void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
