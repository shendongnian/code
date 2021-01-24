        public void Run() {
            MultipartContent h = new MultipartContent("batching", "77f2569d");
            HttpContent content1 = new ByteArrayContent(Encoding.UTF8.GetBytes(data));
            h.Add(content1);
            Task<string> response = PostAsync2("https://server/ucwa/oauth/v1/applications/10751539691/batch", "Bearer", "cwt=AAEBHAEFAAAAAAAFFQAAACd5t5mMpiIgog-06W0EAACBEJH-LcfxNO5SsZ3Ya9NHaRuCAluYgyChwp4HzFpww_sZkaK5SBFBUY4Uk3oW6u6U0Oeh9jWOZoYI8fwX34ce1ggNEJH-LcfxNO5SsZ3Ya9NHaRs", h, "multipart/batching");
            response.Wait();
            string result = response.Result;
        }
        public static async Task<string> PostAsync2(string uri, string token_type, string access_token, HttpContent postData, string accept)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = postData // CONTENT-TYPE header
            };
            // new StringContent(postData, Encoding.UTF8, content_type)
            if (accept != null) request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(accept)); // ACCEPT header
            if (token_type != null && access_token != null) request.Headers.Authorization = new AuthenticationHeaderValue(token_type, access_token);
            HttpResponseMessage g = await client.SendAsync(request);
            if (g.IsSuccessStatusCode)
            {
                return await g.Content.ReadAsStringAsync();
            }
            else
            {
                return null;
            }
        }
