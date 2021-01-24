    public class ShellViewModel : Conductor<Screen>
    {
        private IEventAggregator _eventAggregator;
        public ShellViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            ActivateItem(new AViewModel(_eventAggregator));
        }
    }
