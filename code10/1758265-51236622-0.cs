    public class MyViewModel 
    {
        public ICommand MyCommand {get;set;}
        public MyViewModel()
        {
           MyCommand = new Command(Command_MyCommand);
        }
        public void Command_MyCommand(object paramter)
        {
           // do something nifty
        }
    }
