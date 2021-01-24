    public class SupplierandCategoryViewModel
    {
        public IEnumerable<Category> CategoryModel { get; set; }
        public Supplier SupplierModel { get; set; }
        public int SelectedCategory { get; set; }     <== Add this property
    }
    
