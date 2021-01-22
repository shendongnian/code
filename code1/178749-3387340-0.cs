    class MyClass : System.ComponentModel.INotifyPropertyChanged
    {
        private String _name;
        public String Name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged("Name"); }
        }
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(String propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler temp = PropertyChanged;
            if (temp != null)
            {
                temp(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
