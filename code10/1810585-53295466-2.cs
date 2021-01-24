    public class ItemDesc
    {
        public string value { get; set; }
    }
    
    public class ItemQty
    {
        public int num { get; set; }
        public string unit { get; set; }
    }
    
    public class CreateItemModel
    {
        public ItemDesc ItemDescContext { get; set; }
        public ItemQty ItemQtyContext { get; set; }
    }
