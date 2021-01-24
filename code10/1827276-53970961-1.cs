    public partial class Subscription
    { 
        public Subscription()
        {
            SubscriptionErrors = new HashSet<SubscriptionError>();
        } 
        public int SubscriptionId { get; set; } 
        public virtual ICollection<SubscriptionError> SubscriptionErrors { get; set; }
    }
