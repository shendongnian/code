    public class ApplicationUser : IApplicationUser
    {
       private readonly IHttpContextAccessor httpContextAccessor;
       public ApplicationUser(IHttpContextAccessor httpContextAccessor)
       {
          this.httpConntextAccessor = httpContextAccessor;
       }
       public Guid Id => this.GetUserId();
       public string Name => this.GetUserName();
       private Guid GetUserId()
       {
           var subject = this.httpContextAccessor.HttpContext
                             .User.Identity.Claims
                             .FirstOrDefault(claim => claim.Type == JwtClaimTypes.Subject);
           return Guid.TryParse(subject, out var id) ? id : Guid.Empty;
       }
       private Guid GetUserId()
       {
           return this.httpContextAccessor.HttpContext
                             .User.Identity.Claims
                             .FirstOrDefault(claim => claim.Type == JwtClaimTypes.PreferredUserName);
       }
    }
