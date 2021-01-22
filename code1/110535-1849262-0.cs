    class ItemClass : INotifyPropertyChanged
    {
        public int BoundValue
        {
             get { return m_BoundValue; }
             set
             {
                 if (m_BoundValue != value)
                 {
                     m_BoundValue = value;
                     OnPropertyChanged("BoundValue")
                 }
             }
        }
        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        int m_BoundValue;
    }
