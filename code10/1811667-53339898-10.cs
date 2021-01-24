    public abstract class ViewModelBase
    {
        public ViewModelBase(params ICustomCommand[] commands)
        {
            Commands = new Dictionary<Type,ICustomCommand>();
            foreach (var command in commands)
                Commands.Add(command.GetType(), command);
            RegisterCommands();
        }
        public IDictionary<Type, ICustomCommand> Commands { get; private set; }
        protected abstract void RegisterCommands();
    }
