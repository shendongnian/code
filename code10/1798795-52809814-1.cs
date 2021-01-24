    public class BPCategory 
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string PercentShare { get; set; }
        public string BPCategory1 { get; set; }
        public string DealerCode  { get; set; }
        public string Status { get; set; }
        [NavigationAttribute]
        public List<Product> Product { get; set; }
    }
