	using System.Runtime.Serialization;
	using System.Threading.Tasks;
	using Microsoft.AspNetCore.Mvc;
	namespace test.Controllers
	{
	    [DataContract]
	    public class TestClass
	    {
	        [DataMember]
	        public string Message { get; set; }
	    }
	    
	    [Route("[controller]")]
	    public class TestController : Controller
	    {
	        [HttpPost, Route("test")]
	        public async Task<IActionResult> Test([FromBody]TestClass test)
	        {
	            return Ok("OK");
	        }
	        
	    }
	}
