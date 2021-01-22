    public class Context
    {
    
       static Context _context = null;     
       static object sync = new object();        
       public object Data { get; set; }
    
       private Context()
       {
       }
    
       public static Context GetContext()
       {
          if _context == null) 
          {
             lock (sync)
             {
                if _context == null)
                {
                   _context = new Context(); 
                }
             }
           }
           return _context;
       }
    }
    
    //Load your data, and on any page you need it, just do:
    Context c = Context.GetContext();
    
    //set or get c.Data here
