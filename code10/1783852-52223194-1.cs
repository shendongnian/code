    public static async Task<HttpResponseMessage> SendRequest(HttpMethod method, string endPoint, string accessToken,  dynamic content = null)
            {
                HttpResponseMessage response = null;
                using (var client = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(method, endPoint))
                    {
                        request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
                        if (content != null)
                        {
                            string c;
                            if (content is string)
                                c = content;
                            else
                                c = JsonConvert.SerializeObject(content);
                            request.Content = new StringContent(c, Encoding.UTF8, "application/json");
                        }
    
                        response = await client.SendAsync(request).ConfigureAwait(false);
                    }
                }
                return response;
    
            }
