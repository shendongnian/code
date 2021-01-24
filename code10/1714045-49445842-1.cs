    class Message
    {
        public int Id {get; set;}
        // every Message has zero or more Notifications (one-to-many)
        public virtual ICollection<Notification> Notifications {get; set;}
        ... // other properties
    }
    class Notification
    {
        public int Id {get; set;}
        // every Notifications belongs to exactly one Message using foreign key
        public int MessageId {get; set;}
        public virtual Message Message {get; set;}
        ... // other properties
    }
    class MyDbContext : DbContext
    {
        public DbSet<Message> Messages {get; set;}
        public DbSet<Notification> Notifications {get; set;}
    }
