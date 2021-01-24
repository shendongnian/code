    [Route("api/[controller]")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		private readonly MyWebApiClass _myWebApiClass;
		public ValuesController(MyWebApiClass myWebApiClass)
		{
			_myWebApiClass = myWebApiClass;
		}
			
		// GET api/values
		[HttpGet]
		public ActionResult<IEnumerable<string>> Get()
		{
			return new string[] { _myWebApiClass.Instance.Foo };
		}
	}
