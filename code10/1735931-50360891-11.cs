    public class ProductListViewModel
    {   
        public IList<ProductSummaryViewModel> Products { get; set; }
        public Pager Pager { get; set; }
    }
    public class ProductSummaryViewModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
    }
