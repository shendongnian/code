    [Route("dummy")]
    [HttpPost]
    public async Task<IHttpActionResult> Dummy(Foo req)
    {
    	//logic
    }
    
    public class Foo()
    {
    	public int ObjectOneID {get;set;}
    	public int ObjectTwoID {get;set;}
    }
