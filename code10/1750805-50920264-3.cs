    public class HomeController : Controller
        {
    
            // make a read only field
            private readonly IHttpContextAccessor _httpContextAccessor;
     	
    	//create ctor for controller and inject it
    	public UserService(IHttpContextAccessor httpContextAccessor)
    	{
    		_httpContextAccessor = httpContextAccessor;
    	}
    
    	// now in your post method use this to see what the if anything came in through the request:
    	public async Task<IActionResult> Picload(IFormFile file){//---always null
    		
    	// in my problem I was loading and image from.
     	var file =  _httpContextAccessor.HttpContext.Request.Form.Files[0];
    }
