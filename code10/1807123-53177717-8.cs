    public static class GraphServiceClientExtensions
    {
        public static async Task<List<object>> GetBatchAsync(this GraphServiceClient client, BatchRequest request)
        {
            var batchMessage = request.ToMessage(client);
            await client.AuthenticationProvider.AuthenticateRequestAsync(batchMessage);
            var response = await client.HttpProvider.SendAsync(batchMessage);
            
            var content = await response.Content.ReadAsStringAsync();
            var json = JObject.Parse(content);
            var entities = json["responses"].Select(item =>
            {
                var queryId = (string)item["id"];
                var entityPayload = JsonConvert.SerializeObject(item["body"]);
                var subRequest = request[queryId];
                var entity = JsonConvert.DeserializeObject(entityPayload, subRequest.Value);
                return entity;
            }); 
            return entities.ToList();
        }
    }
