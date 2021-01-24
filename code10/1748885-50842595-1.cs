    public class Relationship
    {
        public int RelationshipId { get; set; }
        public User Friend { get; set; }
        public User User { get; set; }
        public int FriendId { get; set; }
        public int UserId { get; set; }
        public DateTimeOffset RelationshipInitializationDate { get; set; }
    }
    public class User
    {
        public int UserId { get; set; }
    }
