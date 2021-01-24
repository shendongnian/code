    public class JsonContentNegotiator : IContentNegotiator {
        MediaTypeHeaderValue mediaType = MediaTypeHeaderValue.Parse("application/json;charset=utf-8");
        private readonly MyJsonFormatter _jsonFormatter;
     
        public JsonContentNegotiator(MyJsonFormatter formatter) {
            _jsonFormatter = formatter;
        }
     
        public ContentNegotiationResult Negotiate(Type type, HttpRequestMessage request, IEnumerable<MediaTypeFormatter> formatters) {
            var result = new ContentNegotiationResult(_jsonFormatter, mediaType);
            return result;
        }
    }
    
