    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    namespace WebApplication1.Controllers
    {
        [Route("api/[controller]")]
        public class ValuesController : Controller
        {
            // GET api/values
            [HttpGet]
            [ResponseCache(Duration = 123, VaryByHeader = "User-Agent")]
            public IEnumerable<string> Get()
            {
                return new string[] {"value1", "value2"};
            }
        }
    }
