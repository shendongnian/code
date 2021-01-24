    public class SuperJsonOutputFormatter:JsonOutputFormatter
    {
        public SuperJsonOutputFormatter(
            JsonSerializerSettings serializerSettings, 
            ArrayPool<char> charPool) : base(serializerSettings, charPool)
        {
        }
        public override async Task WriteResponseBodyAsync(
            OutputFormatterWriteContext context, 
            Encoding selectedEncoding)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));
            if (selectedEncoding == null)
                throw new ArgumentNullException(nameof(selectedEncoding));
            using (TextWriter writer = 
                context.WriterFactory(
                    context.HttpContext.Response.Body, 
                    selectedEncoding))
            {
                this.WriteObject(writer, new
                {
                    result = context.Object, 
                    resultCode = context.HttpContext.Response.StatusCode, 
                    resultMessage =
                        ((HttpStatusCode) context.HttpContext.Response.StatusCode)
                            .ToString()
                });
                await writer.FlushAsync();
            }
        }
    }
