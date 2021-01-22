    public static class MyExtensions
    {
         public static ProductCollection
                          ToProducts( this IEnumerable<Product> collection )
         {
              return new ProductCollection( collection );
         }
    }
    public class ProductCollection : BaseCollection<Product>
    {
         ...
         public ProductCollection( IEnumerable<Product> collection )
                  : base( collection )
         {
         }
         ...
     }
    var products = (from p in HugeProductCollection
                    where p.Vendor = currentVendor
                    select p).ToProducts();
