    public class UserLogin
    {
        public int UserId { get; set; }
        public string Password { get; set; }
    }
    
    [Route("login")]
    [HttpPost]
    public IHttpActionResult LoginReq([FromBody] UserLogin user)
    {
        //Deserialize the parameters.
    }
