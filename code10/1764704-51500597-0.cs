    public class User
    {
        [Key]
        public Guid Id { get;  set; }
    
        public virtual List<Item> Items { get; set; }
    
        // ...
    }
