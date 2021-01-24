    public class MyViewModel : INotifyPropertyChanged
    {
        private string destinationCode;
        private OperatingMode operatingMode;
        public event PropertyChangedEventHandler PropertyChanged;
        public string DestinationCode
        {
            get
            {
                return destinationCode;
            }
            set
            {
                if (this.destinationCode == value)
                {
                    return;
                }
                destinationCode = value;
                this.OnPropertyChanged();
            }
        }
        public OperatingMode OperatingMode
        {
            get
            {
                return operatingMode;
            }
            set
            {
                if (this.operatingMode == value)
                {
                    return;
                }
                operatingMode = value;
                this.OnPropertyChanged();
            }
        }
        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
