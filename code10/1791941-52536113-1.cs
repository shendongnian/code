    public class MyUserService
    {
        private readonly UserManager<User> _userManager;
        public MyUserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public async Task<bool> GetIsCompanyOwnerAsync(ClaimsPrincipal user)
        {
            var user = await _userManager.GetUserAsync(user);
            return user.CompanyID.HasValue;
        }
    }
