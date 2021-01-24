    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;
    
    namespace StackOverFlowProblemWebApi.Controllers
    {
        public class TestController : ApiController
        {
            [HttpPost]
            public IHttpActionResult TestDictionary([FromBody]Dictionary<string,object> data)
            {
                if (data != null)
                {
                    string string1 = data["a1"].ToString();
                    string string2 = data["a2"].ToString();
                    string string3 = data["a3"].ToString();
                    return Ok("Data Recieved."); // When the data is successfully recieved.
                }
                else
                    return BadRequest("Data is not received.");
            }
        }
    }
