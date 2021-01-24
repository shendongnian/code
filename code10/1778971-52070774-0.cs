      public async Task getAppconfiguration2()
        {
            string URI = "http://169.254.169.254/metadata/identity/oauth2/token?api-version=2018-02-01&resource=https%3A%2F%2Fvault.azure.net";
            Uri uri = new Uri(String.Format(URI));
            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("Metadata", "true");
            HttpRequestMessage request = new HttpRequestMessage
            {
                // Content = new StringContent(body, Encoding.UTF8, "application/json"),
                Method = HttpMethod.Get,
                RequestUri = new Uri(URI)
            };
            var res = await _client.SendAsync(request);
            var content = res.Content.ReadAsStringAsync();
            JObject token = JsonConvert.DeserializeObject<JObject>(content.Result.ToString());
            string token1 = token["access_token"].ToString();
            ConfigurationApp.Encyptionkey = token1.ToString();
            HttpClient _client1 = new HttpClient();
            _client1.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token1);
            HttpRequestMessage request1 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://test.vault.azure.net/secrets/clientid?api-version=2016-10-01")
            };
            var rs = _client1.SendAsync(request1);
            var rk = rs.Result.Content.ReadAsStringAsync();
            JObject clientjson = JsonConvert.DeserializeObject<JObject>(rk.Result.ToString());
            ConfigurationApp.ClientId = clientjson["value"].ToString();
        }
