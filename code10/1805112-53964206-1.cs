    using (var client = new HttpClient())
    {
        var baseUri = new Uri(string.Format("https://api.sandbox.ebay.com/sell/inventory/v1/inventory_item/{0}", SKU));
        client.DefaultRequestHeaders.Add("Authorization", string.Format("Bearer {0}", token));
    
        var payload = JsonConvert.SerializeObject(product);
        var content = new StringContent(payload, Encoding.UTF8, "application/json");
        content.Headers.Add("Content-Language", "en-US");
    
        var response = client.PutAsync(baseUri, content).Result;
        return response.Content.ReadAsStringAsync().Result;
    }
