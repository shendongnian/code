    public class ViewModel{
    private SimpleCommand divertCommand;
    
    
    public ViewModel()
    {
    testCommand = new SimpleCommand
            {
                CanExecuteDelegate = x => true,
                ExecuteDelegate = x => ExecuteCommand()
            };
    }
    
            public SimpleCommand DivertCommand
            {
                get { return divertCommand; }
            }
    
            private void ExecuteCommand()
            {
                DivertCommand.CommandSucceeded = false;
    
    //Your code to execute
    
                DivertCommand.CommandSucceeded = true;
            }}
    }
