    public class ViewModel
    {
        private ICommand doSomethingCommand = new MyCommand();
    
        public ICommand DoSomethingCommand
        {
            get
            {
                return doSomethingCommand;
            }
        }
    }
