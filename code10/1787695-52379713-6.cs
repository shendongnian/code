    public class CustomCommand<T> : ICommand
    {
        private readonly Action<T> _action;
        private readonly Predicate<T> _canExecute;
    
        public CustomCommand(Action<T> action, Predicate<T> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }
    
        public bool CanExecute(object parameter)
        {
            return _canExecute((T)parameter);
        }
    
        public void Execute(object parameter)
        {
            _action((T)parameter);
        }
    
        public event EventHandler CanExecuteChanged;
    }
