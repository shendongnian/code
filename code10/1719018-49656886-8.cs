    public class CounterIconViewModel
    {
        private readonly IMessenger _messenger;
        public CounterIconViewModel(IMessenger messenger)
        {
            _messenger = messenger;
            
            void ConfigureReportPath()
            {
                ...
                _messenger.Send(...);
            }
            ConfigureReportPathCommand = new RelayCommand(ConfigureReportPath);
        }
    }
