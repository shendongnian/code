        public class ProductComparer : IEqualityComparer<Product>
        {
            public bool Equals(Product x, Product y)
            {
                return x.Name == y.Name && x.Id == y.Id;
            }
            public int GetHashCode(Product obj)
            {
                return obj.Id.GetHashCode() ^ obj.Name.GetHashCode();
            }
        }
