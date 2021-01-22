    public class MyRepository : IDisposable
    {
        ...  // everything except the dtor
        public void Dispose()
        {
            if (dc != null)
            {
                dc.Dispose();
            } 
        }
    }
    public class MyController : Controller, IDisposable
    {
        protected MyRepository rep;
    
        public MyController ()
        {
            rep = new MyRepository();
        }
    
        public void Dispose()
        {
           if (rep!= null)
           {
              rep.Dispose();
           } 
        }
    }
