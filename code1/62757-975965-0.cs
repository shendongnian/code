    public class ProductsPackages
    {
        private Dictionary<int, int> _map;
        
        public ProductsPackages(List<Product> products, List<Package> packages,
                                Dictionary<int, int> map)
        {
            _map = map;
        }
        
        public List<Product> Products { get; private set; }
        public List<Package> Packages { get; private set; }
        
        public GetPackages(Product product)
        {
            return (from p in Packages
                    join kvp in _map on p.ID == kvp.Value
                    where kvp.Key == product.ID
                    select p).ToList();
        }
    }
