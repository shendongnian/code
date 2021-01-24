    public async Task<string> makeRequest() {
        var values = new {
            product_id = "10000027819004",
            max_price = 45.0
        };
        var json = JsonConvert.SerializeObject(values); //using Json.Net
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var authHeaders = new AuthenticationHeaderValue("qdaiciDiyMaTjxMt", "74026b3dc2c6db6a30a73e71cdb138b1e1b5eb7a97ced46689e2d28db1050875");
        client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");
        client.DefaultRequestHeaders.Authorization = authHeaders;
        var response = await client.PostAsync("https://sandboxapi.g2a.com/v1/order", content);
        var responseString = await response.Content.ReadAsStringAsync();
        return responseString;
    }
