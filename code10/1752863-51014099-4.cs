        public MessageClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
    
            _client = _httpClientFactory.CreateClient("TestClient");
    
            var body = new { UserName = Username, UserPassword = Password };
            var jsonBody = JsonConvert.SerializeObject(body);
            var content = new StringContent(jsonBody, Encoding.UTF8, ContentType);
    
            var loginEndpoint = Path.Combine(BaseApi, "api/authentication");
    
            _responseMessage = _client.PostAsync(loginEndpoint, content).Result;
        }
    
        public async Task<string> ReadMessages()
        {
            try
            {
                string messages = "";
    
                if (_responseMessage.IsSuccessStatusCode)
                {
                    var messagesEndpoint = Path.Combine(BaseApi, "api/messages/");
                    var cookieContainer = new CookieContainer();
                    var handler = new HttpClientHandler { CookieContainer = cookieContainer };
                    var cookiesToSet = GetCookiesToSet(_responseMessage.Headers, BaseApi);
    
                    foreach (var cookie in cookiesToSet)
                    {
                        handler.CookieContainer.Add(cookie);
                    }
                    var messageResponse = await _client.GetAsync(messagesEndpoint);
                    messages = await messageResponse.Content.ReadAsStringAsync();
                }
                return messages;
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }
