    public class CustomerTransaction
    {
        public int CustomerTransactionId { get; set; }
        public string DateOfPurchase{ get; set; }
        public int PurchaseAmount { get; set; }
        // relationships
        public ProductType ProductType { get; set; }
        public int ProductTypeId { get; set; } 
        
        public StatusType StatusType { get; set; }
        public int StatusID { get; set; }  
    }
    
    public class ProductType
    {
        public int ProductTypeId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        // relationships
        public ICollection<CustomerTransaction> CustomerTransactions { get; set; }
    }
    
    public class StatusType
    {
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public string Description { get; set; }
        
        // relationships
        public ICollection<CustomerTransaction> CustomerTransactions { get; set; }
    }
