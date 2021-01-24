    public class ConnectionItem : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ConnectionItem(string name)
        {
            Name = name;
        }
        public string Name { get; }
        private ConnectionStatus _status;
        public ConnectionStatus Status
        {
            get => _status;
            set
            {
                if (value == _status) return;
                _status = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Status"));
            }
        }
    }
