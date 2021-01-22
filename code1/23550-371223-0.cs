    abstract class BaseCollection<T> : List<T>
    {
        public BaseCollection(IEnumerable<T> collection)
            : base(collection)
        {
        }
    }
    class PruductCollection : BaseCollection<Product>
    {
        public PruductCollection(IEnumerable<Product> collection)
            : base(collection)
        {
        }
    }
    var products = from p in HugeProductCollection
                   where p.Vendor = currentVendor
                   select p;
    PruductCollection objVendorProducts = new PruductCollection(products);
