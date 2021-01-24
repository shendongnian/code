             var url = AppConstants.ApiLoginUrl;
                var uriRequest = new Uri(url);
            
                var content = new HttpFormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username", email),
                    new KeyValuePair<string, string>("password", password)
                });
                using (var httpClient = new Windows.Web.Http.HttpClient())
                {
                    try
                    {
                        var httpResponse = await httpClient.PostAsync(uriRequest, content); 
