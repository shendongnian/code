    public class UserService : IUserService
    {
      private readonly IHttpContextAccessor _httpContextAccessor;
      public UserService(IHttpContextAccessor httpContextAccessor)
      {
        _httpContextAccessor = httpContextAccessor;
      }
      public bool IsUserLoggedIn()
      {
        var context = _httpContextAccessor.HttpContext;
        return context.User.Identities.Any(x => x.IsAuthenticated);
      }
    }
