        private static  async Task GetAsyncToken()
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "http://10.10.100.11:8080/ords/krauta/oauth/token"))
                {
                    var base64Authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes("Bam1EfR6yasT1pJlhOzJmQ..:T6SnqCHsa90dm6wu_l3-2g.."));
                    request.Headers.TryAddWithoutValidation("Authorization", $"Basic {base64Authorization}");
                    request.Content = new StringContent("grant_type=client_credentials", Encoding.UTF8,  "application/x-www-form-urlencoded");
                    var response = await httpClient.SendAsync(request);
                    var result = await response.Content.ReadAsStringAsync();
                    var parseTokenValue = ParseToken.FromJson(result);
                    _tokenValue =  parseTokenValue.AccessToken;
                }
            }
        }
