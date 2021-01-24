    ...    
    namespace CIE_webservice.Controllers {
      [Produces("application/json")]
      [Route("api/CIE")]
      [EnableCors(origins: "http://localhost:4200/", headers: "*", methods: "*")] /* <--- This line remains here or can be added at the action level*/
      public class CIEController : Controller {
        [HttpGet]
        public IEnumerable<string> Get() {
          return new string[] { "value1", "value2" };
        }
    ...
