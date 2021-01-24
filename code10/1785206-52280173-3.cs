    public class MyController: ApiController
    {
        [HttpPost]
        [Route("api/{*[a-zA-Z]}")]
        public async Task<string> PostHandler()
        {
            string result = await Request.Content.ReadAsStringAsync();   
            var requestPath = Request.RequestUri.LocalPath;
            return result;
        }
    } 
