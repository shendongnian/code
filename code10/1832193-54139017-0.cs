    public class PermissionChecker : IPermissionChecker, ITransientDependency
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public PermissionChecker(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<bool> IsGrantedAsync(string permissionName)
        {
            // Get user
            var user = _httpContextAccessor.HttpContext.User;
            // Get claims of type "role"
            var roleClaims = user.Claims.Where(claim => claim.Type == "role");
            // Check for applicable permission based on role permissions
            // ...
        }
        public Task<bool> IsGrantedAsync(UserIdentifier user, string permissionName)
        {
            return IsGrantedAsync(permissionName);
        }
    }
