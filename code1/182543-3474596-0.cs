    public class YourViewModel : ViewModel
    {
        private readonly ICommand doSomethingCommand;
        private string data;
    
        public YourViewModel()
        {
            this.doSomethingCommand = new DelegateCommand(this.DoSomethingWithData);
        }
    
        public ICommand DoSomethingCommand
        {
            get { return this.doSomethingCommand; }
        }
    
        public string Data
        {
            get { return this.data; }
            set
            {
                if (this.data != value)
                {
                    this.data = value;
                    this.OnPropertyChanged(() => this.Data);
                }
            }
        }
    
        private void DoSomethingWithData(object state)
        {
            // do something with data here
        }
    }
