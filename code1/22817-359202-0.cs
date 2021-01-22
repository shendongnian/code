    public class BusinessProducts
    {
       IDataContext _dx;
       BusinessProducts()
       {
          _dx = new SolidDataContext();
       }
    
       BusinessProducts(IDataContext dx)
       {
          _dx = dx;
       }
    }
