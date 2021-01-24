    // your `ConfigureServices()`
    services.AddAuthentication()
            .AddScheme<OurOwnAuthNOpts,OurOwnAuthNHandler>("OurOwnAuthN","Our Own AuthN Scheme",opts=>{
                // ...
            });
    // your action method :
    // GET api/values/5
    [Authorize(AuthenticationSchemes ="OurOwnAuthN")]        
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
        return "value";
    }
