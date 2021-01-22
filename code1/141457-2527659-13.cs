    public class CreateSubscriptionPresenter
    {
        private readonly ICreateSubscriptionView _view;
        private readonly ISubscriptionRepository _subscriptions;
        public CreateSubscriptionPresenter(
            ICreateSubscriptionView view,
            ISubscriptionRepository subscriptions)
        {
            _view = view;
            _subscriptions = subscriptions;
        }
        public void Submit()
        {
            ISubscription subscription;
            if(_view.IsCorporate)
            {
                subscription = new CorporateSubscription();
            }
            else
            {
                subscription = new IndividualSubscription();
            }
            subscription.Notes = _view.Notes;
            _subscriptions.Insert(subscription);
        }
    }
