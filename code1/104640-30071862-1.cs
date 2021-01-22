    public partial class Service1 : ServiceBase
    {
        private readonly PollingService _pollingService = new PollingService();
        public Service1()
        {
            InitializeComponent();
        }
    
        protected override void OnStart(string[] args)
        {
            _pollingService.StartPolling();
        }
    
        protected override void OnStop()
        {
            _pollingService.StopPolling();
        }
    
    }
