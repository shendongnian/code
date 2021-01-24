    public class MainWindowVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private ObservableCollection<string> _ListOfAvaliablePorts;
        public ObservableCollection<string> ListOfAvaliablePorts
        {
            get
            {
                return _ListOfAvaliablePorts;
            }
            set
            {
                if (value != _ListOfAvaliablePorts)
                {
                    _ListOfAvaliablePorts = value;
                    OnPropertyChanged(nameof(ListOfAvaliablePorts));
                }
            }
        }
        public MainWindowVM()
        {
            var comPorts = SerialPort.GetPortNames();
            _ListOfAvaliablePorts = new ObservableCollection<string>(comPorts);
        }
    }
