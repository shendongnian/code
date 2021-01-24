    public class BaseController : Controller
        {
            protected readonly ServiceContext _baseContext;
    
            public BaseController(ServiceContext context)
            {
                _baseContext = context;
            }
    }
    public class HomeController : BaseController
            {
                public HomeController(ServiceContext context)
                :base(context)
                {
                    
                }
        }
