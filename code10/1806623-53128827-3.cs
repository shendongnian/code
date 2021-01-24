    public class ItemDetailTable
    {
        public int ItemSeq { get; set; }
        public string ItemName { get; set; }
        public double? Amount { get; set; }
    
        public string Id { get; set; }   //Foreign key of ItemTable
    }
