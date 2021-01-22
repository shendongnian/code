    public class Command : ICommand
    {
        public delegate void ICommandOnExecute();
        public delegate bool ICommandOnCanExecute();
        private ICommandOnExecute _execute;
        private ICommandOnCanExecute _canExecute;
        public Command(ICommandOnExecute onExecuteMethod, ICommandOnCanExecute onCanExecuteMethod = null)
        {
            _execute = onExecuteMethod;
            _canExecute = onCanExecuteMethod;
        }
        #region ICommand Members
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public bool CanExecute(object parameter)
        {
            return _canExecute?.Invoke() ?? true;
        }
        public void Execute(object parameter)
        {
            _execute?.Invoke();
        }
        #endregion
    }
