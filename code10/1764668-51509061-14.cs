    public class ShellViewModel : Conductor<object>, IHandle<string>
    {
        private readonly IEventAggregator _eventAggregator;
        public ShellViewModel(IEventAggregator eventagg, OtherViewModel otherVM)
        {
            _eventAggregator = eventagg;
            _eventAggregator.Subscribe(this);
            ActivateItem(otherVM);
        }
        public void Handle(string message)
        {
            TargetText = message;
        }
    }
    public class OtherViewModel : Screen
    {
        private readonly IEventAggregator _eventAggregator;
        public OtherViewModel(IEventAggregator eventagg)
        {
            _eventAggregator = eventagg;
        }
        public void CopyText()
        {
            _eventAggregator.PublishOnUIThread(SourceText);
        }
    }
