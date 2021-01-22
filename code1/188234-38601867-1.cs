    public class WindowCommand : ICommand
    {
        private MainWindow _window;
        //Set this delegate when you initialize a new object. This is the method the command will execute. You can also change this delegate type if you need to.
        public Action ExecuteDelegate { get; set; }
        //You don't have to add a parameter that takes a constructor. I've just added one in case I need access to the window directly.
        public WindowCommand(MainWindow window)
        {
            _window = window;
        }
        //always called before executing the command, mine just always returns true
        public bool CanExecute(object parameter)
        {
            return true; //mine always returns true, yours can use a new CanExecute delegate, or add custom logic to this method instead.
        }
        public event EventHandler CanExecuteChanged; //i'm not using this, but it's required by the interface
        //the important method that executes the actual command logic
        public void Execute(object parameter)
        {
            if (ExecuteDelegate != null) //let's make sure the delegate was set
            {
                ExecuteDelegate();
            }
            else
            {
                throw new InvalidOperationException("ExecuteDelegate has not been set. There is no method to execute for this command.");
            }
        }
    }
