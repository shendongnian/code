    public class IndexController : ApiController {
        [HttpGet]
        [HttpPost]
        [HttpPut]
        public IHttpActionResult Handle(string url) {
            string html = File.ReadAllText(@"C:/www/.../index.html");
            var response = Request.CreateResponse(System.Net.HttpStatusCode.OK, html, "text/html");
            return ResponseMessage(response);
        }
    }
