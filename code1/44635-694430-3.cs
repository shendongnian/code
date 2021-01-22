    public class CompositeCommand : ICommand
    {
        private readonly ICommand _command1;
        private readonly ICommand _command2;
        private ICommand _activeCommand;
    
        public CompositeCommand(ICommand command1, ICommand command2)
        {
            _command1 = command1;
            _command2 = command2;
        }
    
        public ICommand ActiveCommand
        {
            get { return _activeCommand; }
        }
    
        public bool CanExecute(object parameter)
        {
            if (_command1.CanExecute(parameter))
            {
                _activeCommand = _command1;
            }
            else if (_command2.CanExecute(parameter))
            {
                _activeCommand = _command2;
            }
            else
            {
                _activeCommand = null;
            }
    
            return _activeCommand != null;
        }
    
        public void Execute(object parameter)
        {
            _activeCommand.Execute(parameter);
        }
    }
