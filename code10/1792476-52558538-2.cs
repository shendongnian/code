    public class MainWindowVM : INotifyPropertyChanged
    {
        public SpecialCommand SpecialCommand { get; set; } = new SpecialCommand();
        private string _text;
        public string Text
        {
            get { return _text; }
            set {
                if (value != _text) {
                    _text = value;
                    OnPropertyChanged(nameof(Text));
                    SpecialCommand.TriggerCanExecuteChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
