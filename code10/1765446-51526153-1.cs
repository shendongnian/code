    public class ProductLookup<T> where T : IProduct
    {
        public static T GetProduct(int id)
        {
            // var productType = GetProductType(id);
            return this.db<T>()
                .Single(p => p.Id == id);
        }
    }
