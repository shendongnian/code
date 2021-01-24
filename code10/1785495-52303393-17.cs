    public class MyController : Controller
    {
        private readonly IAuthorizationService _authorizationService;
    
        public MyController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }
    
        public async Task<IActionResult> DoSomething(int number)
        {
            var requirement = new CustomRequirement
            {
                Number = number
            };
            var result = await _authorizationService.AuthorizeAsync(User, null, requirement);
            if (!result.Succeeded) return Forbid();
    
            return View("success");
        }
    }
