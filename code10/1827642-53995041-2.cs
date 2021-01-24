    using (var client = new HttpClient())
    {
         client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
         client.BaseAddress = new Uri("https://graph.microsoft.com");
         var listItemPayload = new Dictionary<string, object>
         {
            {"Color", "Fuchsia"},
            {"Quantity", 934}
         };
         var requestContent = new StringContent(JsonConvert.SerializeObject(listItemPayload));
         requestContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
         var response = await client.PatchAsync(new Uri($"https://graph.microsoft.com/v1.0/sites/{siteId}/lists/{listId}/items/{itemId}/fields"), requestContent);
         var data = response.Content.ReadAsStringAsync().Result.ToString();
    }
