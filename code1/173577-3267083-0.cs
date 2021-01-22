    public class ProductListingViewModel
    {
        public ProductViewModel ProductViewModel { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
    public class ProductViewModel
    {
        public string CategoryId { get; set; }
    }
