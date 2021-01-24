    public class Your_Class: INotifyPropertyChanged
    {
        private string _destinationCode;
        public string DestinationCode
        {
            get
            {
                return _destinationCode;
            }
            set
            {
                _destinationCode = value;
                RaisePropertyChanged("DestinationCode");
            }
        }
        private OperatingMode _my_Enum;
        public OperatingMode My_Enum
        {
            get
            {
                return _my_Enum;
            }
            set
            {
                _my_Enum = value;
                RaisePropertyChanged("My_Enum");
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
