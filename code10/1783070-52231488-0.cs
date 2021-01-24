    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    
    namespace CoreWebApiTest2.Controllers
    {
        [Route("api/[controller]")]
        [ApiController]
        public class AuthDetailsController : ControllerBase
        {
            // GET: api/AuthDetails
            [HttpGet]
            public Dictionary<string,string> Get()
            {
                return new Dictionary<string, string> { {"X-MS-CLIENT-PRINCIPAL-NAME", Request.Headers["X-MS-CLIENT-PRINCIPAL-NAME"] },
                                                        {"X-MS-CLIENT-PRINCIPAL-ID", Request.Headers["X-MS-CLIENT-PRINCIPAL-ID"]  } };
    
            }
        }
    }
    
