    using System.Net.Http;
    using System.Web.Http;
    using System.Web.Http.Cors;
    
    namespace WebService.Controllers
    {
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public class MainController : ApiController
        {
            // Controller methods not shown...
        }
    }
