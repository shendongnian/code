    [HttpGet]
    [Route("api/checkhealth")]
    public IHttpActionResult CheckHealth() {
        var message = "checkhealth method was invoked";
        return new TextResult(message, Request);
    }
