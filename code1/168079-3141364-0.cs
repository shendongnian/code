    public class Product 
    { 
         ... 
         [OneToOne]
         public Warranty StandardWarranty { get; set; } 
         [OneToOne]
         public Warranty ExtendedWarranty { get; set; } 
    } 
 
    public class Warranty 
    { 
        ... 
        [PrimaryKey(PrimaryKeyType.Foreign)]
        public int ProductId { get; set; }
        [OneToOne]
        public Product Product { get; set; } 
    } 
