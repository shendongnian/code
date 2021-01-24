    public partial class BasePage : ContentPage
    {
        private readonly SubscriptionToken _SomeButtonClickedEventSubscription;
        public BasePage()
        {
            InitializeComponent();
            _SomeButtonClickedEventSubscription = eventAggregator.Value.GetEvent<SomeButtonClickedEvent>().SubscribeAsync(async e =>
        {
            //anything you want to do when button clicked!
        }, threadOption: ThreadOption.UIThread, keepSubscriberReferenceAlive: true);
        }
    }
