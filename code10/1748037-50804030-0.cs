    public class Topic {
        public int TopicId { get; set; }
        // other topic stuff
        public virtual User Owner { get; set; }
        public virtual ICollection<Collaboration> Collaborators { get; set; }
    }
    public class User {
        public int UserId { get; set; }
        // other user stuff
        public virtual ICollection<Collaboration> Collaborators { get; set; }
    }
    public class Collaboration {
        public int CollaborationId { get; set; }
        // other stuff dependent on topic + user
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int TopicId { get; set; }
        public virtual Topic Topic { get; set; }
    }
