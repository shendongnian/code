    public class Repository
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public Repository(IHttpContextAccessor httpContextAccessor)
        {
           _httpContextAccessor = httpContextAccessor;
        }
    
       public void YourRepositoryMethod()
       {
          var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
          // or
          var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
       }
    }
