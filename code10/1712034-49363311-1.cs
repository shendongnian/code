    namespace TestWebApp.Api.Controllers
    {
        using System.Collections.Generic;
        using System.Net.Http.Headers;
        using System.Web.Http;
    
        public class CapController : ApiController
        {
            public IHttpActionResult GetVehicle()
            {
                return this.Unauthorized(new List<AuthenticationHeaderValue>()
                                             {
                                                 new AuthenticationHeaderValue("Authorization")
                                             });
            }
        }
    }
