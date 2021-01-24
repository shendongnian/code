    public class Command : ICommand
        {
            private readonly Action _action;
            private readonly bool _canExecute;
    
            public Command(Action action, bool canExecute = true)
            {
                _action = action;
                _canExecute = canExecute;
            }
    
            public bool CanExecute(object parameter)
            {
                return _canExecute;
            }
    
            public void Execute(object parameter)
            {
                _action();
            }
    
            public event EventHandler CanExecuteChanged;
        }
