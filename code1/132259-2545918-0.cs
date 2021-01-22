    class PersonViewModel : INotifyPropertyChanged
    {
        Person p = new Person();
        public string First
        {
            get { return p.First; }
            set
            {
                p.First = value;
                onPropertyChanged("First");
            }
        }
        public string Last
        {
            get { return p.Last; }
            set
            {
                p.Last = value;
                onPropertyChanged("Last");
            }
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        private void onPropertyChanged(string propertyName)
        {
            if (PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName);
            }
        }
        #endregion
    }
