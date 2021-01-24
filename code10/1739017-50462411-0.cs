    public class CustomerTransaction
    {
        public int CustomerTransactionId{ get; set; },
        public int ProductTypeId {get; set; }, //joins to ProductTypeTable
        public int StatusID {get; set; },  //joins to StatusTypeTable
        public string DateOfPurchase{ get; set; },
        public int PurchaseAmount { get; set; },
        // Add this
        public virtual ProductType ProductType { get; set;}
        public virtual StatusType StatusType { get; set;} 
    }
