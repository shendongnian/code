    public class Product
    {
        public string Name { get; set; }
        public List<Variant> Variants { get; set; }
        public List<int> AttachedCategoryIds { get; set; }
    }
    
    public class Variant
    {
        public string LongDescription { get; set; }
    }
