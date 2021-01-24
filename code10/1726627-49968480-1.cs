    public static HttpResponseMessage MakeRequest(string url)
    {
        using (var client = new HttpClient())
        {
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };
            HttpResponseMessage response = client.SendAsync(request).Result;
            var statusCode = (int)response.StatusCode;
            // We want to handle redirects ourselves so that we can 
            // determine the final redirect Location (via header)
            if (statusCode >= 300 && statusCode <= 399)
            {
                var redirectUri = response.Headers.Location;
                if (!redirectUri.IsAbsoluteUri)
                {
                    redirectUri = new Uri(request.RequestUri.
                        GetLeftPart(UriPartial.Authority) + redirectUri);
                }
                
                return MakeRequest(redirectUri.AbsoluteUri);
            }
            return response;
        }
    }
