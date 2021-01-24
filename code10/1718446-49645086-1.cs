    namespace CelusionWebapi.Controllers
    {
        public class TestController : ApiController
        {
            
            // GET: api/Test
            public async Task<IEnumerable<Employee>> Get()
            {
             
                List<Employee> employee = new List<Employee>();
                employee = await GetAllEmployees();
                return employee;
            }
         
    
            // POST: api/Test
            public void Post([FromBody]Models.Employee employee)
            {
              
            }
            [NonAction]
            public async Task<List<Employee>> GetAllEmployees()
            {
    
                string Baseurl = ConfigurationManager.AppSettings["TestBaseurl"].ToString();
    
                using (var client = new HttpClient())
                {
                    //Passing service base url  
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    HttpResponseMessage Res = await client.GetAsync(string.Format("GetAllEmployees"));
                    List<Employee> emoloyeelist = new List<Employee>();
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var EmpResponse = Res.Content.ReadAsStringAsync();
                       emoloyeelist = JsonConvert.DeserializeObject<List<Employee>>(EmpResponse.Result);
                      
                    }
                    //returning the employee list to view  
                    return emoloyeelist;
                }
            }
        }
    }
