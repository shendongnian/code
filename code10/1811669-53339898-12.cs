    public abstract class ViewModelBase
    {
        public ViewModelBase(params ICustomCommand[] commands)
        {
            _commands = commands;            
            RegisterCommands();
        }
        private IEnumerable<ICustomCommand> _commands;
        protected abstract void RegisterCommands();
        //This method gets you the commands
        protected T GetCommand<T>() where T : ICustomCommand
        {
            var command = _commands.FirstOrDefault(c => typeof(T).IsAssignableFrom(c.GetType()));
            return (T)command ;
        }
    }
    public class LoginViewModel : ViewModelBase
    {
        public LoginViewModel(ILoginCommand command):base(command)
        {
        }
        protected override void RegisterCommands()
        {
            //Get the command from the base class
            var command = GetCommand<ILoginCommand>();
            command?
            .Configure(
                execute: (msg) => { Login(User); },
                canExecute: (x) => { return CanLogin(); }
                );
        }
    }
    public class LoginCommand : ILoginCommand
    {
    }
    public interface ILoginCommand : ICustomCommand
    {
    }
