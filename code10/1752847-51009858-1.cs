    public class MyController : Controller {
        private readonly IHttpClientFactory factory;
        
        public MyController(IHttpClientFactory factory) {
            this.factory = factory;
        }
        
        [HttpGet]
        public async Task<IActionResult> SomeAction() {
            //create the named client via the factory
            var client = factory.CreateClient("TestClient");
            //base api is already configured into the client.
            var loginEndpoint = "api/authentication";
            var body = new { Username = username, Password = password };
            var jsonBody = JsonConvert.SerializeObject(body);
            var content = new StringContent(jsonBody, Encoding.UTF8, contentType);
            var loginResponse = await client.PostAsync(loginEndpoint, content);
            
            //...do something with the response
            
            return Ok();
        }
    }
