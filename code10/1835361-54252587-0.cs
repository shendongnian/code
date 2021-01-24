    public class NotifyingData<T> : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private T _Data;
        public T Data
        {
            get { return _Data; }
            set { _Data = value; NotifyPropertyChanged(); }
        }
    }
