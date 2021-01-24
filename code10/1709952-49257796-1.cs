    [Route("dummy")]
    [HttpPost]
    public async Task<IHttpActionResult> Dummy(Foo req)
    {
    	//logic
    }
    
    public class Foo
    {
    	public CustomObjectBody ObjectOneID {get;set;}
    	public CustomObjectBody ObjectTwoID {get;set;}
    }
    
    public class CustomObjectBody
    {
    	public int Property1 {get;set;}
    	public int Property2 {get;set;}
    }
