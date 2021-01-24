    public class CounterIconViewModel
    {
        private sealed class Generated
        {
            public IMessenger messenger;
            void ConfigureReportPath()
            {
                ...
                messenger.Send(...);
            }
        }
        public CounterIconViewModel(IMessenger messenger)
        {
            var generated = new Generated();
            generated.messenger = messenger;
            ConfigureReportPathCommand = new RelayCommand(new Action(generated.ConfigurReportPath));
        }
    }
