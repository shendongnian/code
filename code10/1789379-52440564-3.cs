    class Class1:Observable
    {
        public Class1()
        {
            PropertyChanged += Class1_PropertyChanged;
        }
    
        private void Class1_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Property))
            {
                //here is a method to handle Property changed event
            }
        }
    
        string propertyValue;
        public string Property
        {
            get => propertyValue;
            set => SetPropertyAndNotifyIfNeeded(ref propertyValue, value);
        }
    }
