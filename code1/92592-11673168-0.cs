    public class PNetworkOptions : IBaseInterface, INotifyPropertyChanged
    {
        private string _IPAddress;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
        public string IPAddress
        {
            get { return _IPAddress; }
            set
            {
                if (value != null && value != _IPAddress)
                {
                    _IPAddress = value;
                    NotifyPropertyChanged("IPAddress");
                }
            }
        }
    }
