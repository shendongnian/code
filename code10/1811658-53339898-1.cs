    public abstract class ViewModelBase
    {
        public ViewModelBase(ICustomCommand command)
        {
            _command= command;
            RegisterCommands();
        }
        private ICustomCommand _command;
        public ICustomCommand Command
        {
            get
            {
                return _command;
            }
            set
            {
               _command = value;
            }
        }
    }
