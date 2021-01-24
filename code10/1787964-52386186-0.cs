     using (var server = TestServer.Create<Startup>())
        {
            var result = await server.HttpClient.GetAsync("api/Orders/id");
            string responseContent = await result.Content.ReadAsStringAsync();
            var entity = JsonConvert.DeserializeObject<List<Orders>>(responseContent);
            // other code
        }
