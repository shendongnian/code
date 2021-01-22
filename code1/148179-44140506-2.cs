    using (var httpClientHandler = new HttpClientHandler())
    {
        httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => {
            if (sslPolicyErrors == SslPolicyErrors.None)
            {
                return true;   //Is valid
            }
            if (cert.GetCertHashString() == "99E92D8447AEF30483B1D7527812C9B7B3A915A7")
            {
                return true;
            }
            return false;
        };
        using (var httpClient = new HttpClient(httpClientHandler))
        {
            var httpResponse = httpClient.GetAsync("https://example.com").Result;
        }
    }
