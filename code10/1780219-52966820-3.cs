    Route("api/Users")]
    public class UsersController : Controller
    {
        private readonly UsersContext _context;
      
        public IActionResult Login()
        {
            return View();
        }
    
        public ViewResult Users() => View();
    
        public UsersController(UsersContext context)
        {
            _context = context;
        }
    
        //[HttpGet]
        [Route("Users")]
        [HttpGet]
        public IActionResult GoToUsers()
        {
            try
            {
                //return RedirectToPage("/Users");
                return Users();
            }
            catch (Exception ex)
            {
    
                throw ex;
            }
    
        }
    }
