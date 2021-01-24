    public class Item
    {
        [Key]
        public Guid Id { get; set; }
    
        public string ItemName { get; set; }
        // Relation to User
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    
        protected Item()
        {    }
        public Item(string name, User user)
        {
            Id = Guid.NewGuid();
            UserId = user.Id;
            ItemName = name;
        }
    }
