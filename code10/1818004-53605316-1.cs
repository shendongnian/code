    public class YourClass 
    {
       private readonly IHttpContextAccessor _httpContextAccessor;
       public YourClass(IHttpContextAccessor httpContextAccessor)
       {
          _httpContextAccessor = httpContextAccessor;
       }
    
       public void YourMethod()
       {
          // access HttpContext with __httpContextAccessor.HttpContext
       }
    }
