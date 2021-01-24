    public class MyViewModel: ViewModelBase
    {
        public MyViewModel()
        {
            DoSomethingCommand = new BasicCommamd(()=>OnDoSomething());
        }
        public ICommand DoSomethingCommand {get;}
        private void OnDoSomething()
        {
            // put whatever you want the command to do here
        }
    }
