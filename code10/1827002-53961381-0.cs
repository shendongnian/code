    public static async Task<string> HttpClient(string url) 
        {
            using(HttpClient client = new HttpClient()) 
            {
                client.BaseAddress = new Uri(url);
                
                client.DefaultRequestHeaders
                      .Accept
                      .Add(new MediaTypeWithQualityHeaderValue("application/json")); // ACCEPT header
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, "");
                request.Content = new StringContent("{\"id\" : 1}",
                                    Encoding.UTF8,  
                                    "application/json"); // REQUEST header
                
                
                HttpResponseMessage response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();               
            }
        }
