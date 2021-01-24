        public static async Task<HttpResponseMessage> SignedGetRequest(this HttpClient client, string url, Dictionary<string, string> data)
        {   
            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(url),
                Method = HttpMethod.Get
            };
            var keys = data.Keys.OrderBy(x => x);
            var headerSig = "";
            foreach (var key in keys)
            {
                headerSig = headerSig + "x-" + data[key] + "-";
                request.Headers.Add("x-" + key, data[key]);
            }
            // TODO: Time based nonce hash
            var nonce = String.Format("{0:r}", DateTime.Now);
            headerSig = headerSig + nonce + "-" + Environment.GetEnvironmentVariable("ApiKey");
            var hash = Security.CalculateHash(headerSig);
            request.Headers.Add("signature", hash);
            request.Headers.Add("nonce", nonce);
        
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return  await client.SendAsync(request);
        }
