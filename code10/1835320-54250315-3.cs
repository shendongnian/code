    public async Task GetUrlData(string url, string branchKey)
            {
                HttpClient client = new HttpClient();
    
                client.BaseAddress = new Uri("https://api.branch.io");
                client.DefaultRequestHeaders
                    .Accept
                    .Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string requestUrl = $"/v1/url?url{url}&key={branchKey}";
    
                var payload = new Rootobject();
    
                var stringPayload = JsonConvert.SerializeObject(payload);
                var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(requestUrl, httpContent);
    
                if (response.Content != null)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                }
            }
