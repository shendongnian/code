    public class Item
    {
        public int ItemID { get; private set; }
    
        public int? GlobalItemID { get; set; }
    
        public int? DepositItemID { get; set; }
    
        [ForeignKey("GlobalItemID")]
        public Item GlobalItem { get; set; }
    
        [ForeignKey("DepositItemID")]
        public Item DepositItem { get; set; }
    
        protected Item() { }
    }
