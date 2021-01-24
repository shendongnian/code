    class Comment
    {
        public int Id {get; set;}
        ...
        // Every Comment is posted by exactly one User, using foreign key
        public int CommentedByUserId {get; set;}
        public virtual User User {get; set;}
        // Every Comment is about exactly one Post, using foreign key
        public int PostId {get; set;}
        public virtual Post Post {get; set;}
        // Every Comment has zero or more Likes (one-to-many)
        public virtual ICollection<Like> Likes {get; set;}
    }
    class Like
    {
        public int Id {get; set;}
        ...
        // Every Like is created by exactly one User, using foreign key
        public int LikedByUserId {get; set;}
        public virtual User User {get; set;}
        // Every Like is about exactly one Comment, using foreign key
        public int CommentId {get; set;}
        public virtual Comment Comment {get; set;}
    }
