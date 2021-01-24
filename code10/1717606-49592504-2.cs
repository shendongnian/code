    public class User
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public virtual ICollection<UserSubscription> Subscriptions { get; set; }
        }
    public class Subscription
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
      public class UserSubscription
    {
        public int ID { get; set; }
        public int SubscriptionID { get; set; }
        public decimal Price { get; set; }
        public int UserID { get; set; }
        public virtual User { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
