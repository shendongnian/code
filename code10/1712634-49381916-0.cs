    public class Command : ICommand
    {
        private readonly Action _action;
        public Command(Action action)
        {
            _action = action;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            _action();
        }
    }
    public class SharedViewModel : INotifyPropertyChanged
    {
        private string _labelText;
        public string LabelText
        {
            get { return _labelText; }
            set
            {
                _labelText = value;
                OnPropertyChanged();
            }
        }
        private ICommand _buttonClickCommand;
        public ICommand ButtonClickCommand => _buttonClickCommand ?? (_buttonClickCommand = new Command(ButtonClickAction));
        public void ButtonClickAction()
        {
            LabelText = "Updated Text";
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
