        Startup.cs
         //services section
         services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    
    [Authorize]
    public class HomeController : Controller
    {
      #region DI         
      private string UserEmail;
      private readonly IHttpContextAccessor _httpContextAccessor;
      public HomeController(IHttpContextAccessor httpContextAccessor)
      {
        _httpContextAccessor = httpContextAccessor;
        UserEmail = _httpContextAccessor.HttpContext.User.Claims
                    .FirstOrDefault(c => c.Type == "preferred_username")?.Value;
               
      }
      #endregion DI 
       public IActionResult Index()
       {            
          ViewBag.UserEmail = UserEmail;   
          return View();
       }
    }
