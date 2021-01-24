    public class MyController: ApiController
    {
    
        [HttpPost]
        [Route("api/{*path}")]
        public string PostHandler(string path)
        {
            string result = Request.Content.ReadAsStringAsync().Result;   
            var requestPath = Request.RequestUri.LocalPath;
    
            return result;
        }
    }   
