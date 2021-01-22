    public class FakeView : IView
    {
        public event SubscriptionHandler<EventHandler> Subscription;
        public event SubscriptionHandler<EventHandler> Unsubscription;
        private IView _view;
        public FakeView(IView view)
        {
            Assert.IsNotNull(view);
            _view = view;
        }
        public bool IsPostBack => _view.IsPostBack;
        public bool IsValid => _view.IsValid;
        public event EventHandler Init
        {
            add
            {
                Subscription?.Invoke(nameof(Init), value);
                _view.Init += value;
            }
            remove
            {
                Unsubscription?.Invoke(nameof(Init), value);
                _view.Init -= value;
            }
        }
        public event EventHandler Load
        {
            add
            {
                Subscription?.Invoke(nameof(Load), value);
                _view.Init += value;
            }
            remove
            {
                Unsubscription?.Invoke(nameof(Load), value);
                _view.Init -= value;
            }
        }
        public void DataBind()
        {
            _view.DataBind();
        }
    }
