public class RepositoryUserAccount : IRepositoryUserAccount
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public RepositoryUserAccount(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    public async Task EnableAuthenticator()
    {
        ClaimsPrincipal currentUser = _httpContextAccessor.HttpContext.User;
        var currentUserName = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;
    }
}
