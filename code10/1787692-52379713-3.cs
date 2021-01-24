     public class CustomCommand<T> : ICommand
        {
            private readonly Action<T> _action;
            private readonly Func<T, bool> _canExecute;
    
            public CustomCommand(Action<T> action, Func<T, bool> canExecute)
            {
                _action = action;
                _canExecute = canExecute;
            }
    
            public bool CanExecute(object parameter)
            {
                return _canExecute((T)parameter);
            }
    
            public bool CanExecute(T parameter)
            {
                return _canExecute(parameter);
            }
    
            public void Execute(object parameter)
            {
                _action((T)parameter);
            }
    
            public void Execute(T parameter)
            {
                _action(parameter);
            }
    
            public event EventHandler CanExecuteChanged;
        }
