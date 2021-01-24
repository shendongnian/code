    public class CounterIconViewModel
    {
        private readonly IMessenger _messenger;
        private void ConfigureReportPath()
        {
            ...
            _messenger.Send(...);
        }
        public CounterIconViewModel(IMessenger messenger)
        {
            _messenger = messenger;
            ConfigureReportPathCommand = new RelayCommand(new Action(ConfigureReportPath);
        }
    }
