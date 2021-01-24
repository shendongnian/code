    public partial class SubscriptionError
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubscriptionErrorId { get; set; } 
        public int? SubscriptionId { get; set; } 
        public virtual Subscription Subscription { get; set; }
    }
