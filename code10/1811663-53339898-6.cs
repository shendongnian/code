    public abstract class ViewModelBase<T> where T:ICustomCommand
    {
        public ViewModelBase(T command)
        {
            _command= command;
            RegisterCommands();
        }
        private T _command;
        public T Command
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
