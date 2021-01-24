    public class PlainTextMediaTypeFormatter : MediaTypeFormatter
    {
        public PlainTextMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/plain"));
        }
        public override Task<object> ReadFromStreamAsync(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
        {
            var source = new TaskCompletionSource<object>();
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    readStream.CopyTo(memoryStream);
                    var text = Encoding.UTF8.GetString(memoryStream.ToArray());
                    source.SetResult(text);
                }
            }
            catch (Exception e)
            {
                source.SetException(e);
            }
            return source.Task;
        }
        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, System.Net.TransportContext transportContext, System.Threading.CancellationToken cancellationToken)
        {
            var bytes = Encoding.UTF8.GetBytes(value.ToString());
            return writeStream.WriteAsync(bytes, 0, bytes.Length, cancellationToken);
        }
        public override bool CanReadType(Type type)
        {
            return type == typeof(string);
        }
        public override bool CanWriteType(Type type)
        {
            return type == typeof(string);
        }
    }
