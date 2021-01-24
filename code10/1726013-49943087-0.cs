    public class Transfer : INotifyPropertyChanged {
        private int _currentStep;
        public int CurrentStep
        {
            get { return _currentStep; }
            set
            {
                if (_currentStep != value) {
                    _currentStep = value;
                    OnPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
