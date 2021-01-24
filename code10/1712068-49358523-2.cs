    public class Reaction
    {
        public int Id { get; set; }
    
        // every Reaction belongs to exactly one Post using foreign Key:
        public int PostId {get; set;}
        public virtual Post Post {get; set; }
 
        ...
    }
