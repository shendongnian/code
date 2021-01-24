      public class HomeController : Controller
        {
            private readonly MyService _myService;
    
            public HomeController (MyService myService)
            {
                _myService = myService;
            }
       }
