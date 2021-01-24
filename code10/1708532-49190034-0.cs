    public class HomeController : ApiController
    {
        [HttpGet]
        [Route]
        public HttpResponseMessage Get()
        {
            var response = new HttpResponseMessage();
            // add your homepage html here
            response.Content = new StringContent("<html><body>Your Home Page</body></html>");
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/html");
           return response;
        }
    }
