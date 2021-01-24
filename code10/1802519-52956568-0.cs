    class ProductComparer : IEqualityComparer<Product>
    {
        public bool Equals(Product x, Product y)
        {
            if (ReferenceEquals(x, y)) return true;
    
            if (ReferenceEquals(x, null) || ReferenceEquals(y, null)) return false;
    
            return x.Code == y.Code && (x.Name.Equals(y.Name, StringComparison.InvariantCultureIgnoreCase));
        }
    
        public int GetHashCode(Product product)
        {
            var hashProductName = product.Name == null ? 0 : product.Name.ToLower().GetHashCode();
    
            var hashProductCode = product.Code.GetHashCode();
    
            return hashProductName ^ hashProductCode;
        }
    }
