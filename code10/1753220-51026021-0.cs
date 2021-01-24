    public class ApiRequestModel 
    {
       // define all your required properties client going to send
    }
    [HttpPost]
    public IActionResult Post([FromBody] ApiRequestModel c)
