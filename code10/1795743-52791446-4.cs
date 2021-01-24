        public class UICommand : ICommand
        {
           private readonly Action<object> _execute;
           private readonly Func<bool> _canExecute;
           public UICommand(Action<object> onExecuteMethod, Func<bool> onCanExecuteMethod = 
                null)
          {
            _execute = onExecuteMethod;
            _canExecute = onCanExecuteMethod;
          }
          public bool IsCanExecute { get; set; }
          #region ICommand Members
        public event EventHandler CanExecuteChanged
        {
            add { if (_canExecute != null) CommandManager.RequerySuggested += value; }
            remove { if (_canExecute != null) CommandManager.RequerySuggested -= value; }
        }
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
        public bool CanExecute(object parameter)
        {
            IsCanExecute = (_canExecute == null || _canExecute());
            return IsCanExecute;
        }
        #endregion
        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
        }
