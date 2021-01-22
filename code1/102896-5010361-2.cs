    public class CommandBinding<T> where T : ButtonBase
    {
        private T _invoker;
        private ICommand _command;
        public CommandBinding(T invoker, ICommand command)
        {
            _invoker = invoker;
            _command = command;
            _invoker.Enabled = _command.CanExecute(null);
            _invoker.Click += delegate { _command.Execute(null); };
            _command.CanExecuteChanged += delegate { _invoker.Enabled = _command.CanExecute(null); };
        }
    }
