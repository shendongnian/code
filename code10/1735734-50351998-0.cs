    public class CustomApiController : ApiController
    {
        public class JsonResult<Target> : NegotiatedContentResult<Target>
        {
            public JsonResult(HttpStatusCode statusCode, Json<Target> content, ApiController controller) : base(statusCode, content.Data, controller)
            {
                this.Content = content;
            }
            public JsonResult(HttpStatusCode statusCode, Target content, ApiController controller) : base(statusCode, content, controller)
            {
            }
            public JsonResult(HttpStatusCode statusCode, Target content, IContentNegotiator contentNegotiator, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters)
                : base(statusCode, content, contentNegotiator, request, formatters)
            {
            }
            public new Json<Target> Content { get; private set; }
        }
        
        public JsonResult<Target> CreateResponse<Target>(Target Data, string Notify, HttpStatusCode Code = HttpStatusCode.OK)
        {
            Json<Target> json = new Json<Target>
            {
                Notify = Notify,
                Data = Data
            };
            return new JsonResult<Target>(Code, json, this);
        }
    }
