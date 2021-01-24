    public partial class SubscriptionError
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SubscriptionErrorId { get; set; } 
        [Key]
        public int SubscriptionId { get; set; } 
        public virtual Subscription Subscription { get; set; }
    }
