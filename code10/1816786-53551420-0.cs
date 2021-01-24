                using (var httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri("API URL");
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Authorization = new
                        System.Net.Http.Headers.AuthenticationHeaderValue("Pass your token value or API key");
                    HttpResponseMessage response = await httpClient.GetAsync(endpoint);
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        if (string.IsNullOrEmpty(result))
                            return "Success";
                        else
                            return result;
                    }
                    else if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new UnauthorizedAccessException();
                    }
                    else
                    {
                        throw new Exception(await response.Content.ReadAsStringAsync());
                    }
                }
