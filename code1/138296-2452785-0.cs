    abstract class Product 
    {
       public abstract bool CheckProduct();
    }
    class ProductBookDetail : Product
    {
       public override bool CheckProduct()
       {
          //Here we can check ProductBookDetail
       }
    }
    
    class ProductDetailDVD : Product
    {
       public override bool CheckProduct()
       {
          //Here we can check ProductDetailDVD
       }
    }
    
    public class ProductServiceGeneric<T> : IProductServiceGeneric<T> where T : ProductDetail
    {
        public void SaveOrUpdate(T product)
        {
           if (!product.CheckProduct())
           {
               //product checking failes. Add necessary logic here
           }
        }
    }
