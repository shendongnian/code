    public class TokenController : ApiController
    {
    	/// <summary>
    	/// API endpoint to login a user
    	/// </summary>
    	/// <param name="data">The login data</param>
    	/// <returns>Unauthorizied if the login fails, The jwt token as string if the login succeded</returns>
    	[AllowAnonymous]
    	[Route("login")]
    	[HttpPost]
    	public IActionResult Login([FromBody]LoginData data)
    	{
    		var token = _manager.ValidateCredentialsAndGenerateToken(data);
    		if (token == null)
    		{
    			return Unauthorized();
    		}
    		else
    		{
    			return Ok(token);
    		}
    	}
    }
