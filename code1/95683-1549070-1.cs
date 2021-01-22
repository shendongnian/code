    class MyType : INotifyPropertyChanged, INotifyPropertyChanging
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event PropertyChangingEventHandler PropertyChanging;
    
        protected void UpdateField<T>(ref T field, T newValue, string propertyName)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newValue))
            {
                OnPropertyChanging(propertyName);
                field = newValue;
                OnPropertyChanged(propertyName);
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this,
                new PropertyChangedEventArgs(propertyName));
        }
        protected void OnPropertyChanging(string propertyName)
        {
            PropertyChangingEventHandler handler = PropertyChanging;
            if (handler != null) handler(this,
                new PropertyChangingEventArgs(propertyName));
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
