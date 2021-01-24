services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
then in your class libray
public class Test 
{
    private IHttpContextAccessor _httpContextAccessor;
    public Test(IHttpContextAccessor httpContextAccessor)
    {
         _httpContextAccessor = httpContextAccessor;
    }
    public void Foo()
    {
        _httpContextAccessor.HttpContext.Request.Path..
    }
}
