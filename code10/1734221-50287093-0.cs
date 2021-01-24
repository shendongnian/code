    HttpClient _client = new HttpClient();
            var apiParams = new Dictionary<string, string>();
            apiParams.Add("FileName", RCFileName ?? string.Empty);
            string _BaseUrl = ConfigurationManager.AppSettings["WebAPIBaseURL"];
            _client.BaseAddress = new Uri(_BaseUrl);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = _client.GetAsync(string.Format("{0}{1}",
                                            _BaseUrl,
                                            "test/RegenerateReport?FileName=" + RCFileName)
                                          );
            if (response.IsCompleted)
                _client.Dispose();//Dispose the client object
