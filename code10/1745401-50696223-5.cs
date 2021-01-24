    public class ProductViewModel {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
    }
    public class ProductsPageViewModel {
        public ProductsPageViewModel {
            ProductsList = new List<ProductViewModel>();
        }
    
        public ICollection<ProductViewModel> ProductsList { get; set; }
    }
