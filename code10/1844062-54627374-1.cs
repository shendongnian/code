    public class Info
    {
        public int Id { get; set; }
        public string Value { get; set; }
        ... // other properties
 
        // every info belongs to exactly one Todo, using foreign key
        public int TodoId {get; set;}
        public virtual Todo Todo { get; set; }
    }
