    public class ExampleData : INotifyPropertyChanged
    {
    
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        public decimal SampleDecimal
        {
            get { return _sampleDecimal; }
            set
            {
                _sampleDecimal = value;
                OnPropertyChanged();
            }
        }
    
        private decimal _sampleDecimal = 1.0m;
    }
