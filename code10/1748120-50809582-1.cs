    public class tbluser
    {
       private static MyContext _context = new MyContext();
       
       // ...
    
       public static List<tbluser> list()
       {
          return _context.tblusers.ToList();
       }
    }
