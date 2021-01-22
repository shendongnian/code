    class TestClass : INotifyPropertyChanged
    {
        private int _testProperty;
        public int testProperty
        {
            get { return _testProperty; }
            set
            {
                if (_testProperty == value)
                    return;
                _testProperty = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("testProperty"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public TestClass()
        {
            testProperty = 10;
        }
    }
