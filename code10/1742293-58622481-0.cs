<!-- language: c# -->
   public interface IUserProvider
   {
        string GetUserId();
   }
Than implementation is
<!-- language: c# -->
    public class UserProvider : IUserProvider
    {
        private readonly IHttpContextAccessor _context;
        public UserProvider (IHttpContextAccessor context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public string GetUserId()
        {
            return _context.HttpContext.User.Claims
                       .First(i => i.Type == ClaimTypes.NameIdentifier).Value;
        }
    }
So you can use interface `IUserProvider` in your controller without inheritance
<!-- language: c# -->
    [Authorize]
    [ApiController]
    public class MyController : ControllerBase
    {        
        private readonly IUserProvider _userProvider;
        public MyController(IUserProvider userProvider)
        {            
            _userProvider = userProvider ?? throw new ArgumentNullException(nameof(userProvider ));
        }
        [HttpGet]
        [Route("api/My/Something")]
        public async Task<ActionResult> GetSomething()
        {
            try
            {
                var userId= _userProvider.GetUserId();
            }
        }
     }
