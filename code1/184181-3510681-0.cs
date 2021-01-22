    public class PurchaseOrder
    {
        public double TotalPurchases { get; set; }
        public double MaxPurchases { get; private set; }
    
        public PurchaseOrder()
        {
            this.MaxPurchases = 10;
        }
    }
