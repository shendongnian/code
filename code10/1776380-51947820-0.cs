    public class Patient : INotifyPropertyChanged
    {
        private Units _units;
        public Units Units
        {
            get { return _units; }
            set
            {
                _units = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged(nameof(FormattedTemperature));
            }
        }
        private double _temperature;
        public double Temperature
        {
            get { return _temperature; }
            set
            {
                _temperature = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged(nameof(FormattedTemperature));
            }
        }
        public string FormattedTemperature =>
            _temperature.ToString() + (_units == Units.Celsuis ? " C" : " F");
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    public enum Units
    {
        Celsuis,
        Fahrenheit
    }
