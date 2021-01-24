    class DataItem : INotifyPropertyChanged
    {
        event PropertyChangedEventHandler PropertyChanged;
 
        private bool _column1;
        public bool Column1
        {
            get { return _column1; }
            set 
            {
                _column1 = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArg("Column1"));
            }
        }
    }
