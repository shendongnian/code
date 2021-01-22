    public class MyController : Controller
    {
       private readonly ISomeService _someService;
       //Constructor Injection. 
       public MyController(ISomeService someService){
           _someService = someService;
        }
    }
