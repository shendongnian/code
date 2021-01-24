    public class RelayCommand : ICommand
    {
        readonly Action<object> _ActionToExecute;
        readonly Predicate<object> _ActionCanExecute;
        public RelayCommand(Action<object> inActionToExecute): this(inActionToExecute, null)
        {
        }
        public RelayCommand(Action<object> inActionToExecute, Predicate<object> inActionCanExecute)
        {
            if (inActionToExecute == null)
                throw new ArgumentNullException("execute");
            _ActionToExecute = inActionToExecute;
            _ActionCanExecute = inActionCanExecute;
        }
        public bool CanExecute(object parameter)
        {
            return _ActionCanExecute == null ? true : _ActionCanExecute(parameter);
        }
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public void Execute(object parameter)
        {
            _ActionToExecute(parameter);
        }
    }
