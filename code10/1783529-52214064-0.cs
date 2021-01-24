    public class ReportInformation : INotifyPropertyChanged
    {
        private int _numberField;
        private DateTime _dateField;
        public int NumberField
        {
            get => _numberField;
            set 
            {
                if (_numberField != value)
                {
                    _numberField = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(ReportLabel));
                }
            }
        }
        public DateTime DateField
        {
            get => _dateField;
            set
            {
                if (_dateField != value)
                {
                    _dateField = value;
                    RaisePropertyChanged();
                    RaisePropertyChanged(nameof(ReportLabel));
                }
            }
        }
        public string ReportLabel => $"{NumberField}: {DateField}";
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void RaisePropertyChanged([CallerMemberName]string name = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
