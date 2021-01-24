    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private string _someString;
    
        public string SomeString
        {
            get => _someString;
            set
            {
                if (value == _someString) return;
                _someString = value;
                OnPropertyChanged();
            }
        }
    
        public event PropertyChangedEventHandler PropertyChanged;
    
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
