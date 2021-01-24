       class MyEntry : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private String _strName, _strAge;
        public String StrAge
        {
            get { return _strAge; }
            set
            {
                _strAge = value;
                RaisePropertyChanged("StrAge");
            }
        }
        public String StrName
        {
            get { return _strName; }
            set
            {
                _strName = value;
                RaisePropertyChanged("StrName");
            }
        }
        public MyEntry()
        {
        }
        public MyEntry(String name, String age)
        {
            StrName = name;
            StrAge = age;
        }
        private void RaisePropertyChanged(String propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
