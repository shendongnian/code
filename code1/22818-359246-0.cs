    public class BusinessProducts
    {
       IDataContext _dx;
    
       BusinessProducts()
       {
          _dx = Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<IDataContext>();
       }
    
       public List<Product> GetProducts()
       {
        return dx.GetProducts();
       }
    }
