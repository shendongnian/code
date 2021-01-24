    using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://api.vasttrafik.se");
                    var content = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("grant_type", "client_credentials"),
                        new KeyValuePair<string, string>("scope", Injected.Instance.Platform.GetId())
                    });
                    
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", System.Convert.ToBase64String(plainTextBytes));
                  
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                    var result = await client.PostAsync("token",content);
                    string resultContent = await result.Content.ReadAsStringAsync();
                  
                }
