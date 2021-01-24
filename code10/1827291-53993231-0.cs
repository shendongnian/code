    public class Subscription
    {
         public int SubscriptionId { get; set; }
         public virtual SubscriptionError SubscriptionError { get; set; }
    }
    public class SubscriptionError
    {
        [ForeignKey("Subscription")]
        public int SubscriptionId { get; set; }
        [Required]
        public virtual Subscription Subscription { get; set; }
    }
