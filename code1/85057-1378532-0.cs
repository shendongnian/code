    public class Product
    {
        public IList<Item> Items {get;}
    
        public int GetMaxItemSmth()
        {
            return new ProductItemQuerySpecifications().GetMaxSomething(this);
        }
    }
    
    public class ProductItemQuerySpecifications()
    {
       public int GetMaxSomething(product)
       {
          var respository = MyContainer.Resolve<IProductRespository>();
          return respository.GetMaxSomething(product);
       }
    }
