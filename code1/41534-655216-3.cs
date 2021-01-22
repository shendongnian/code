    public void Foo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    
        private int _someValue;
        public int SomeValue
        {
            get { return _someValue; }
            set { _someValue = value; NotifyPropertyChanged("SomeValue"); }
        }
    }
