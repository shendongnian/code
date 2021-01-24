    public class MyController : Controller
    {
       private AppContext context;
    
       public MyController(AppContext context)
       {
          this.context = context;
       }
    }
