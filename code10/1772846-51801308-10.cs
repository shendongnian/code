    public class RelayCommand<T> : ICommand
    {
        private readonly T _argument;
        private readonly Action<T> _execute;
        public RelayCommand(T argument, Action<T> execute)
        {
            _execute = execute;
            _argument = argument;
        }
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter)
        {
            _execute(_argument);
        }
        public event EventHandler CanExecuteChanged;
    }
