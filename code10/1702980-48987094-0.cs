    public class Review
    {
        public int Id { get; set; }
        //...
        public int ReviewerId { get; set; }
        public virtual User Reviewer { get; set; }
        public int ReviewedUserId { get; set; }
        public virtual User ReviewedUser { get; set; }
    }
