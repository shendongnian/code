    class User
    {
         public int Id {get; set;}
         ...
         // Every User creates zero or more Posts (one-to-many)
         public virtual ICollection<Post> Posts {get; set;}
         // Every User creates zero or more Comments (one-to-many)
         public virtual ICollection<Comment> Comments {get; set;}
         // Every User creates zero or more Likes (one-to-many)
         public virtual ICollection<Like> Likes {get; set;}
    }
    class Post
    {
        public int Id {get; set;}
        ...
        // Every Post is posted by exactly one User, using foreign key
        public int PostedByUserId {get; set;}
        public User User {get; set;}
        // Every Post has zero or more Comments (one-to-many)
        public virtual ICollection<Comment> Comments {get; set;}
    }
