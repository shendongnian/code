    public bool MakeRequest(url)
    {
        using (var client = new HttpClient() { Timeout = _timeout })
        {
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };
            HttpResponseMessage response = client.SendAsync(request).Result;
            var statusCode = (int)response.StatusCode;
            // We want to handle redirects ourselves so that we can determine the final redirect Location (via header)
            if (statusCode >= 300 && statusCode <= 399)
            {
                var redirectUri = response.Headers.Location;
                if (!redirectUri.IsAbsoluteUri)
                {
                    redirectUri = new Uri(request.RequestUri.GetLeftPart(UriPartial.Authority) + redirectUri);
                }
                _status.AddStatus(string.Format("Redirecting to {0}", redirectUri));
                return MakeRequest(redirectUri);
            }
            else if (!response.IsSuccessStatusCode)
            {
                throw new Exception();
            }
            return true;
        }
    }
