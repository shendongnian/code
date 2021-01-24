    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri("https://mainnet.infura.io/qhggowRXK7HIgXB0NEyw");
        client.DefaultRequestHeaders.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
        var requestBody = new
        {
            jsonrpc = "2.0",
            method = "eth_blockNumber",
            @params = new int[]{},
            id = 83,
        };
    
        HttpResponseMessage apiResponse = await client.PostAsJsonAsync(client.BaseAddress, requestBody);
    
        if (apiResponse.IsSuccessStatusCode)
        {
            var documentResponse = await apiResponse.Content.ReadAsStringAsync();
            dynamic response = JsonConvert.DeserializeObject(documentResponse);
        }                
    }
