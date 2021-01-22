    public class WebClientWithResponse : WebClient
    {
        // we will store the response here. We could store it elsewhere if needed.
        // This presumes the response is not a huge array...
        public byte[] Response { get; private set; }
    
        protected override WebResponse GetWebResponse(WebRequest request)
        {
            var response = base.GetWebResponse(request);
            var httpResponse = response as HttpWebResponse;
            if (httpResponse != null)
            {
                using (var stream = httpResponse.GetResponseStream())
                {
                    using (var ms = new MemoryStream())
                    {
                        stream.CopyTo(ms);
                        Response = ms.ToArray();
                    }
                }
            }
            return response;
        }
    }
