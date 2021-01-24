    namespace WebApi.Controllers
    {
        public class EventController : ApiController
        {
            [HttpGet]
            public HttpResponseMessage Tags(string token, int messageId)
            {
                return ApiCall<List<EntityTag>>.CallApi(token, ServicesMessage.GetTags(messageId));
            }
    
            [HttpGet]
            public HttpResponseMessage Events(string token, int eventId)
            {
                return ApiCall<EntityEvent>.CallApi(token, ServicesEvent.Get(eventId));
            }
        }
    }
