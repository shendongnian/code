    class DemoModel : INotifyPropertyChanged
    {
        protected String _text;
        public String Text
        {
            get { return _text; }
            set { _text = value; RaisePropertyChanged("Text"); }
        }
        protected String _dynamicText;
        public String DynamicText
        {
            get { return _dynamicText; }
            set { _dynamicText = value; RaisePropertyChanged("DynamicText"); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler temp = PropertyChanged;
            if (temp != null)
            {
                temp(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
