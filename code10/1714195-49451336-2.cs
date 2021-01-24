    public class UserController : Controller
    {
    	[HttpGet]
    	public IActionResult Profile(string username)
    	{
    		return Ok();
    	}
    }
