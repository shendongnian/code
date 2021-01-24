     using (var client = new HttpClient(handler: clientHandler, disposeHandler: true))
                {
                    client.BaseAddress = new Uri(Host);
                    
                    var url = $"{Path}";
                    var parameters = new Dictionary<string, string> {
                        { "V", Version },
                        { "ref", Reference },
                        { "password", Password }
                    };
    
                    var encodedContent = new FormUrlEncodedContent(parameters);
    
                    var response = client.PostAsync(url, encodedContent).Result;
                    result = response.Content.ReadAsStringAsync().Result;
                }
                return result;
