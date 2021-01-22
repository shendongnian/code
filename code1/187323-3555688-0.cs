    public interface ICommand
    {
       bool CanExecute(string command);
       void Execute();
    }
    public class MethodACommand : ICommand
    {
        private MyForm form;
        public MethodACommand(MyForm form) {... }
        public bool CanExecute(string command) { return command.Equals("MethodA"); }
        public void Execute() { form.MethodA(); }
    }
    public class CommandManager
    {
        public CommandManager(IEnumerable<ICommand> commandString) {...}
        public Execute(string command) 
        {
            foreach(var command in Commands)
            {
                 if (command.CanExecute(commandString))
                 {
                     command.Execute();
                     break;
                 }
            }
        }
    }
    protected void Button_Click(object sender, EventArgs e)
    {
        string arg = ((Button)sender).CommandArgument;  // = MethodA
        commandHandler.Execute(arg);
    }
