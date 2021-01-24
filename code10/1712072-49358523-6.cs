    public class Post
    {
        public int Id { get; set; }
        // every Post belongs to exactly one User using foreign key
        public int UserId { get; set; }
        public virtual Post Post {get; set;}
        // every Post has zero or more Reactins (one-to-many)
        public virtual IColleciton<Reaction> Reactions {get; set;}
        ...   
    }
