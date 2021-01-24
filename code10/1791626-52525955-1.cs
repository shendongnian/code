    public class RelayCommand : ICommand
    {
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;
        public RelayCommand(Action<object> execute) : this(execute, null) { }
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute)); _canExecute = canExecute;
        }
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke(parameter) ?? true;
        }
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
        public void Execute(object parameter) { _execute(parameter); }
    }
    public class ViewModel:INotifyPropertyChanged
    {
        public bool IsChecked { get; set; } 
        public RelayCommand IsCheckedCommand { get; set; }
        public ViewModel()
        {
            IsCheckedCommand = new RelayCommand(m => IsCheckedCommandExecute());
        }
        private void IsCheckedCommandExecute()
        {
            IsChecked = !IsChecked;
            OnPropertyChanged(nameof(IsChecked));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
