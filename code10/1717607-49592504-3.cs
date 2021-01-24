    public class User
        {
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public int CurrentSubscriptionID { get; set; }
            public virtual Subscription Subscription { get; set; }
        }
    public class Subscription
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
