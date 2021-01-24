    public class Test1PageViewModel : ShellIntegratedViewModel
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly INavigationService _navigationService;
        Action action;
        public Test1PageViewModel(IEventAggregator eventAggregator, INavigationService navigationService)
            : base(eventAggregator)
        {
            _eventAggregator = eventAggregator;
            _navigationService = navigationService;
            NavigateCommand = new DelegateCommand(OnNavigateCommand);
            action = new Action(()=> {
                _eventAggregator.GetEvent<LogEvent>().Publish("Test1 Hashcode: " + this.GetHashCode());
            });
            _eventAggregator.GetEvent<TestEvent>().Subscribe(action);
        }
        private void OnNavigateCommand()
        {
            _eventAggregator.GetEvent<TestEvent>().Unsubscribe(action);
            _navigationService.Navigate("Test2", null);
        }
        public DelegateCommand NavigateCommand { get; private set; }
    }
