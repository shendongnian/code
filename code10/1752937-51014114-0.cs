    public class BasketItem
    {
        [Key]
        public int BasketItemId { get; set; }
        // add the actual columns
        public int ProductId { get; set; }    
        public int BaskedId { get; set; }
        public Product Product {get;set;}
        public Basket Basket {get; set; }
    }
    public class Basket
    {
        [Key]
        public int BasketId { get; set; }
        // I believe it's a string but it could be a System.Guid instead
        public string IdentityUserId { get; set; }
    
        public IdentityUser IdentityUser { get; set; }
    }
