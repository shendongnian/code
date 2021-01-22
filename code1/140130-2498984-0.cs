    public class MyProgram
    {
        public void Run()
        {
            Visitor v = new Visitor("Mary");
            Debug.Assert(v.SubscriptionLinkText == "Join now");
            v.IsSubscribed = true;
            Debug.Assert(v.SubscriptionLinkText == "Today's special");
            
            v.IsSubscribed = false;
            Debug.Assert(v.SubscriptionLinkText == "Join now");
        }
    }
    public class Visitor
    {
        public string Name { get; set; }
        private bool _isSubscribed;
        public bool IsSubscribed
        {
            get { return this._isSubscribed; }
            set
            {
                if (value != this._isSubscribed)
                {
                    this._isSubscribed = value;
                    this.OnSubscriptionChanged();
                }
            }
        }
        private SubscriptionBase _subscription;
        public string SubscriptionLinkText
        {
            get { return this._subscription.LinkText; }
        }
        public Visitor(string name)
        {
            this.Name = name;
            this._isSubscribed = false;
            this.OnSubscriptionChanged();
        }
        private void OnSubscriptionChanged()
        {
            // Consider also defining an event and raising it here
            this._subscription =
                SubscriptionBase.GetSubscription(this.IsSubscribed);
        }
    }
    abstract public class SubscriptionBase
    {
        // Factory method to get instance
        static public SubscriptionBase GetSubscription(bool isSubscribed)
        {
            return isSubscribed ?
                    new Subscription() as SubscriptionBase
                    : new NoSubscription() as SubscriptionBase;
        }
        
        abstract public string LinkText { get; }
    }
    public class Subscription : SubscriptionBase
    {
        public override string LinkText
        {
            get { return "Join now"; }
        }
    }
    public class NoSubscription : SubscriptionBase
    {
        public override string LinkText
        {
            get { return "Today's Special"; }
        }
    }
