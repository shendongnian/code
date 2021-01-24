    using System;
    using System.Windows.Input;
    
    namespace WpfApp1
    {
        public class RelayCommand : ICommand
        {
            private readonly Func<object, bool> _canExecute;
            private readonly Action<object> _execute;
    
            public RelayCommand(Action<object> execute) : this(execute, s => true)
            {
            }
    
            public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
            {
                _execute = execute;
                _canExecute = canExecute;
            }
    
            public bool CanExecute(object parameter)
            {
                return _canExecute(parameter);
            }
    
            public void Execute(object parameter)
            {
                _execute(parameter);
            }
    
            public event EventHandler CanExecuteChanged
            {
                add => CommandManager.RequerySuggested += value;
                remove => CommandManager.RequerySuggested -= value;
            }
        }
    }
