    class MyType : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged, PropertyChanging;
    
        protected void UpdateField<T>(ref T field, T newValue, string propertyName)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                PropertyChangedEventArgs args = new PropertyChangedEventArgs(propertyName);
                InvokePropertyHandler(PropertyChanging, args);
                field = newValue;
                InvokePropertyHandler(PropertyChanged, args);
            }
        }
        protected void InvokePropertyHandler(PropertyChangedEventHandler handler, PropertyChangedEventArgs args)
        {
            if (handler != null) handler(this, args);
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { UpdateField(ref name, value, "Name"); }
        }
        private DateTime dateOfBirth;
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { UpdateField(ref dateOfBirth, value, "DateOfBirth"); }
        }
    }
