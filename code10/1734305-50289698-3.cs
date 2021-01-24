    public class TransactionTP
    {
        public List<ItemUtility> itemsUtilities { get; set; }
        public  int transactionUtility { get; set; }
        public TransactionTP(List<ItemUtility> itemsUtilities, int transactionUtility)
        {
            this.itemsUtilities = itemsUtilities;
            this.transactionUtility = transactionUtility;
        }
    }
