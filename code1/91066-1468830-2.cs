    public class RelayCommand : ICommand
    {
        public RelayCommand(Predicate<object> canExecute, Action<object> execute)
        {
            // ... I think you can see where this goes ...
        }
        // ... etc ...
        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
