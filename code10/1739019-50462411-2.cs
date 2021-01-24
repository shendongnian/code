    public class CustomerTransaction
    {
        public int CustomerTransactionId{ get; set; },
        public int ProductTypeId {get; set; }, //joins to ProductTypeTable
        public int StatusID {get; set; },  //joins to StatusTypeTable
        public string DateOfPurchase{ get; set; },
        public int PurchaseAmount { get; set; },
        // Add this
        public ProductType ProductType { get; set;}
        public StatusType StatusType { get; set;} 
    }
