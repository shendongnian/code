    public class ProductLookup<T> where T : IProduct
    {
        public static T GetProduct(int id)
        {
            // var productType = GetProductType(id);
            //You can pass either FruitProduct or CerealProduct here (Although, you will ONLY
            //be able to access Id here, as this function only knows it's an IProduct)
            return this.db<T>()
                .Single(p => p.Id == id);
        }
    }
