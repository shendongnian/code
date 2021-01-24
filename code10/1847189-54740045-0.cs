    [Route("test")]
    [HttpPost]
    public IActionResult Login([FromBody]LoginDto x)
    {
    	return Ok(x);
    }
    public class LoginDto
    {
    
    	public string UserName { get; set; }
    	[Newtonsoft.Json.JsonProperty("password")]
    	public string Pssd { get; set; }
    }
