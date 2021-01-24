        public async Task<string> PostHttpSPContentWithToken(string url, string token)
        {
            var httpClient = new HttpClient();
            HttpResponseMessage response;
            try
            {
                var root = new
                {
                    fields = new Dictionary<string, string>
                    {
                       { "Title", TitleText.Text },
                       { "UserName", UserNameText.Text },
                       { "UserAge", UserAgeText.Text },
                       { "UserTitle", UserTitleText.Text }
                    }
                };
                string content = JsonConvert.SerializeObject(root);
                var request = new HttpRequestMessage(HttpMethod.Post, url);
                //Add the token in Authorization header
                request.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                request.Content = new StringContent(content, Encoding.UTF8, "application/json");
                response = await httpClient.SendAsync(request);
                var responseString = await response.Content.ReadAsStringAsync();
                return responseString;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
