    public class Item 
    {
        public Guid Id { get; }
     
        public Item()
        {
            Id = Guid.NewGuid();
        }
    }
