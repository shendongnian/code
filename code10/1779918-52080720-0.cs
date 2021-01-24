    public class Item
    {
        public int ItemID { get; private set; }
    
        public int GlobalItemID { get; set; }
    
        public int DepositItemID { get; set; }
    
        public virtual Item GlobalItem { get; set; }
    
        public virtual Item DepositItem { get; set; }
    
        protected Item() { }
    }
