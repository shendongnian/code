    public static class Extensions
    {
        public static UriRequest Request(this Uri uri)
        {
            return new UriRequest(uri);
        }
        public static UriRequest KeepTrying(this UriRequest uriRequest)
        {
            uriRequest.KeepTrying = true;
            return uriRequest;
        }
    }
    public class UriRequest
    {
        public Uri Uri { get; set; }
        public bool KeepTrying { get; set; }
        public UriRequest(Uri uri)
        {
            this.Uri = uri;
        }
        public string ToHtml()
        {
            var client = new System.Net.WebClient();
            do
            {
                try
                {
                    using (var reader = new StreamReader(client.OpenRead(this.Uri)))
                    {
                        return reader.ReadToEnd();
                    }
                }
                catch (WebException ex)
                {
                    // log ex
                }
            }
            while (KeepTrying);
            return null;
        }
        public static implicit operator string(UriRequest uriRequest)
        {
            return uriRequest.ToHtml();
        }    
    }
