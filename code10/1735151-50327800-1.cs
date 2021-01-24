    public class ResponseCodeAttribute : ResultFilterAttribute,IApiResponseMetadataProvider
    {
        public int StatusCode {get;}
        public Type Type { get; }=typeof(void);
        public ResponseCodeAttribute(int statusCode)=>StatusCode=statusCode;
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            context.HttpContext.Response.StatusCode = StatusCode;
        }
        void IApiResponseMetadataProvider.SetContentTypes(MediaTypeCollection contentTypes)
        {            
        }
    }
