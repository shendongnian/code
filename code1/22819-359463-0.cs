    public class BusinessProducts
    {
       IDataContext _dx;
       BusinessProducts() : this(new DataContext()) {}
       BusinessProducts(IDataContext dx)
       {
          _dx = dx;
       }
    
       public List<Product> GetProducts()
       {
        return dx.GetProducts();
       }
    }
