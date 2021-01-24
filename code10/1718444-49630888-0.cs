	namespace CelusionWebapi.Controllers
	{
		public class TestController : ApiController
		{
			private const string Baseurl = ConfigurationManager.AppSettings["TestBaseurl"].ToString();
			private static readonly HttpClient client;
			public static TestController(){
				client = new HttpClient();
				client.BaseAddress = new Uri(Baseurl);
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
			}
			
			// GET: api/Test
			public Enumerable<string> Get()
			{
				return new string[] { "Hello ", "Arjun" };
			}
			// GET: api/Test/5
			public string Get(int id)
			{
				return "Hello This Is Arjun ";
			}
			// POST: api/Test
			public async Task<IActionResult> Post([FromBody]Employee employee)
			{
				empolyee = await CheckMapping(employee);
				... do something with Employee
                return this.created(//location, employee);
			}
			private async Task<Employee> CheckMapping(Employee mapping)
			{
				HttpResponseMessage Res = await this.client.GetAsync(string.Format("Get?id={0}", mapping.EmployeeId));             
				if (Res.IsSuccessStatusCode)
				{
					mapping = await Res.Content.ReadAsAsync<Employee>();                 
				}
				//returning the employee list to view  
				return mapping;
			}
		}
	}
