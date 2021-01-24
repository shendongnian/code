        public class UserController : Controller
    {
        private IApplicationUserStore _userStore;
        public UserController(IApplicationUserStore userStore)
        {
            _userStore = userStore;
        }
        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] CreateApplicationUserViewModel model)
        {
            var user = new ApplicationUser()
            {
                Email = model.Email,
                UserName = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
            var result = await _userStore.Create(user, model.Password);
            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("error", error.Description);
                }
                return BadRequest(result.Errors);
            }
        }
    }
