    public interface IProduct
    {
       public decimal Sell(); // computes price
       ...
    }
.....
    
    IProduct product = ProductCreator.CreateProduct(); //Factory Method we have here
    SellThisProduct(product);
    
    //...
    
    private void SellThisProduct(IProduct product)
    {
       var price = product.Sell();
       ...
    }
    internal class Soda : IProduct
    {
       public decimal Sell()
       {
           this.Price + TaxService.ComputeTax( this.Price );
       }
    }
    internal class Book : IProduct
    {
        public decimal Sell()
        {
             return this.Price;
        }
    }
