     namespace TestWebApp.Api.Controllers
     {
        using System.Web.Http;
    
        public class CapController : ApiController
        {
            public IHttpActionResult GetVehicle()
            {
                return this.Unauthorized();
            }
        }
    }
