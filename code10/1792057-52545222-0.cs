    class Class1 : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int MyProp { get;  set; }
        public string stringProp { get; set; }
        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
