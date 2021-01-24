    public class MyJsonConverter : JsonConverter
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public MyJsonConverter(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var context = httpContextAccessor.HttpContext;
            //...
        }
        //...
    }
