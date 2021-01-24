    class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel ( )
        {
            DoMethod = new DelegateCommand ( Method );
        }
        public async void Method ( )
        {
            // Lets define our time consuming worker
            string Worker ( )
            {
                Thread.Sleep ( 5000 );
                return "result";
            };
            // This part executes in the main thread
            IsBusy = true;
            // The Scheduler will direct the main thread to execute something else while the task is not done
            var result = await Task.Factory.StartNew ( Worker );
            // Task is done, the rest will execute back in the main thread
            IsBusy = false;
        }
        public ICommand DoMethod { get; private set; }
        public  bool  IsBusy { get { return _isBusy; }
                               set { _isBusy = value; OnPropertyChanged ( ); } }
        private bool _isBusy;
    }
