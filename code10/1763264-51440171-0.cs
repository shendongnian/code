    public class EventController : ApiController
    {
        [HttpGet]
        [Route("gettags")]
        public HttpResponseMessage GetTags(string token, int messageId)
        {
            return ApiCall<List<EntityTag>>.CallApi(token, ServicesMessage.GetTags(messageId));
        }
    
        [HttpGet]
        [Route("get")]
        public HttpResponseMessage Get(string token, int eventId)
        {
            return ApiCall<EntityEvent>.CallApi(token, ServicesEvent.Get(eventId));
        }
    }
