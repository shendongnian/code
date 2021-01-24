    public class AuthFormatter : TextOutputFormatter
    {
        public AuthFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/json"));
            SupportedEncodings.Add(Encoding.UTF8);
        }
        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, 
            Encoding selectedEncoding)
        {
            var settings = new JsonSerializerSettings 
            {
                ContractResolver = new AuthorizedPropertyContractResolver(context.HttpContext.User)
            };
            await context.HttpContext.Response.WriteAsync(
                JsonConvert.SerializeObject(context.Object, settings));
        }
    }    
