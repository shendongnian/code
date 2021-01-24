    public class User
    {
        public int Id { get; set; }
        // every user has zero or more Posts (one-to-many)
        public virtual ICollection<Post> Posts { get; set; }
        ...
    }
