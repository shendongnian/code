      [Serializable]
      public abstract class ProductAbstract : IProduct
      {
        // define all methods/attributes of interface IProduct here as abstract methods/attributes
      }
        [WebMethod]
        Public double CalculateTotal(ProductAbstract product, int Quantity)
        {  
           return product.Price * Quantity;
        }
