    public class MyController: ApiController
    {
        [HttpPost]
        [Route("api/{*[a-zA-Z]}")]
        public string PostHandler()
        {
            string result = Request.Content.ReadAsStringAsync().Result;   
            var requestPath = Request.RequestUri.LocalPath;
            return result;
        }
    }   
