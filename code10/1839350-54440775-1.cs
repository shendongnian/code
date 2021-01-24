    [HttpGet]
    [Route("EnableAuthenticator")]
    public void EnableAuthenticator()
    {
       var user = HttpContext.User;
    }
