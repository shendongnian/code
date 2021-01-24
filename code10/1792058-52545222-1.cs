     class Class1 : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            public int MyProp { get; protected set; }
            public string stringProp { get; protected set; }
    
            public void SetProperty(string propertyName, object value)
            {
                var properties = this.GetType().GetProperties();
    
                var property = properties.ToList().Where(x=> x.Name == propertyName ).FirstOrDefault() ;
    
                if (property != null)
                {
                    property.SetValue(this, value);
                    NotifyPropertyChanged(propertyName);
                }
            }
    
            // This method is called by the Set accessor of each property.  
            // The CallerMemberName attribute that is applied to the optional propertyName  
            // parameter causes the property name of the caller to be substituted as an argument.  
            private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    
        }
