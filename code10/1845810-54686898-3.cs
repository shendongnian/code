        public class Command : ICommand
        {
            public delegate void ICommandOnExecute();
            private ICommandOnExecute _execute;
            public event EventHandler CanExecuteChanged;
            public Command(ICommandOnExecute onExecuteMethod)
            {
                _execute = onExecuteMethod;
            }
            public bool CanExecute(object parameter)
            {
                return true;
            }
            public void Execute(object parameter)
            {
                _execute?.Invoke();
            }
        }
