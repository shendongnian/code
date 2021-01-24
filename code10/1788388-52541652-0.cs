    public class MyRestClient : RestClient
    {
        public MyRestClient(string baseUrl) : base(baseUrl)
        { }
        public override IRestResponse Execute(IRestRequest request)
        {
            request.ResponseWriter = s => { };
            request.AdvancedResponseWriter = (input, response) => response.RawBytes = ReadAsBytes(input);
            return base.Execute(request);
        }
        private static byte[] ReadAsBytes(Stream input)
        {
            var buffer = new byte[16 * 1024];
            using (var ms = new MemoryStream())
            {
                int read;
                try
                {
                    while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                    { ms.Write(buffer, 0, read); }
                    return ms.ToArray();
                }
                catch (WebException ex)
                { return Encoding.UTF8.GetBytes(ex.Message); }
            };
        }
    }
