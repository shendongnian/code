        private async Task<string> Execute(string url, string query, string user, string pasword)
        {
            HttpClient httpClient = new HttpClient();
            var baseUri = new Uri(url, UriKind.Absolute);
            Uri request = new Uri(baseUri, query);    // e.g. http://somedomain.com/endpoint?arg1=xyz&arg2=abc
            
            // Add a new Request Message
            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Get, request);
            
            // add headers -> CURLOPT_USERPWD equivalent
            var encodedStr = Convert.ToBase64String(Encoding.Default.GetBytes(string.Format("{0}:{1}", user, password)));
            var authorizationKey = "Basic" + " " + encodedStr;    // Note: Basic case sensitive
            requestMessage.Headers.Add("Authorization", authorizationKey);
            // if POST - do this instead
            // content
            //HttpContent content = new StringContent(jsonContent);     // string jsonContent i.e. JsonConvert.SerializeObject(YourObject);
            //requestMessage.Content = content;
            //requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            // execute
            HttpResponseMessage responseMessage = await httpClient.SendAsync(requestMessage);
            var responseString = await responseMessage.Content.ReadAsStringAsync();
            return responseString;
        }
     
    
