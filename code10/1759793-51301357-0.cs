    [Route("api/[controller]")]
    public class PostsApiController : UmbracoApiController
    {
    	[HttpGet]
    	public MyDTO Test()
    	{
    	    // 1. Get content from umbraco
    	    var content = Umbraco.TypedContent(1122);
    		
    		// 2. Create instance of your own DTO
    		var myDTO = new MyDTO();
    		
    		// 3. Pupulate your DTO
    		myDTO.SomeProperty = content.SomeProperty;
    		
    		// 4. return it
    		return myDTO;
    	}
    }
