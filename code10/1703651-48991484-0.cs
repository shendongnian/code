    class Question
    {
        public int Id {get; set;}    // will become primary key
        // every Question has zero or more Tags
        public virtual ICollection<Tag> Tags {get; set;}
        // other properties:
        public string Text {get; set;}
        ...
    }
    class Tag
    {
        public int Id {get; set;}    // will become primary key
        // every Tag is used by zero or more Questions
        public virtual ICollection<Question> Questions {get; set;}
        // other properties:
        public string Text {get; set;}
        ...
    }
    public MyDbContext : DbContext
    {
        public DbSet<Question> Questions {get; set;}
        public DbSet<Tag> Tags {get; set;}
    }
