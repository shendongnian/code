    public class SomeController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
        public SomeController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }
        public async Task<IActionResult> Create([FromForm]MyCustomDto myDto)
        {
            var authorizationResult = await _authorizationService.AuthorizeAsync(User, myDto, "MyCustomPolicy");
            if (!authorizationResult.Succeeded)
                return User.Identity.IsAuthenticated ? Forbid() : (IActionResult)Challenge();
            // Do some stuff here
        }
