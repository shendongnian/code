    public class Subscription
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int UserID { get; set; }
        public virtual User { get; set; }
    }
