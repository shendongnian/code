    public class SomeController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        public SomeController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }
        public async Task<IActionResult> Create([FromForm]MyCustomDto myDto)
        {
            await _authorizationService.AuthorizeAsync(User, myDto, "MyCustomPolicy");
            // Do some stuff here
        }
    }
