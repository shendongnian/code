    public class Frame
    {
        public int productTypeId { get; set; }
        public int productCategoryId { get; set; }
        public string name { get; set; }
        public double memberCost { get; set; }
        public double providerCost { get; set; }
    }
    
    public class YourResponse
    {
        public List<Frame> frames { get; set; }
    }
