    public class YourClass 
    {
       private readonly IHttpContextAccessor _httpContextAccessor;
       public YourClass(IHttpContextAccessor httpContextAccessor)
       {
          _httpContextAccessor = httpContextAccessor;
       }
    
       public void YourMethod()
       {
          string myHostUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
       }
    }
