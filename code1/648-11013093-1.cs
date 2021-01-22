    public class DataController : ApiController
    {
        public HttpResponseMessage<string[]> Get()
        {
            HttpResponseMessage<string[]> response = new HttpResponseMessage<string[]>(
                Repository.Get(true),
                new MediaTypeHeaderValue("application/json")
            );
            return response;
        }
    }
