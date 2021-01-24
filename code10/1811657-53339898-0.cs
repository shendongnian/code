    public abstract class ViewModelBase
    {
        public ViewModelBase(ICustomCommand loginCommand)
        {
            _loginCommand = loginCommand;
            RegisterCommands();
        }
    }
