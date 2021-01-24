     public async Task<HttpResponseMessage> SendMessageAsync(string message)
        {
            var payload = new
            {
                text = message,
                channel="x",
                userName="y",
            };
            HttpClient httpClient = new HttpClient();
            var serializedPayload = serializer.ToJson(payload);
            var response = await httpClient.PostAsync("url",
                new StringContent(serializedPayload, Encoding.UTF8, "application/json"));
            return response;
        }
