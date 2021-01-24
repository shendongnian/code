    client.BaseAddress = new Uri("http://localhost:89**2/");
    client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
    var content = new StringContent(JsonConvert.SerializeObject(myViewModel), 
                                    Encoding.UTF8, "application/json");
    var result = client.PostAsync("api/abcd", content).Result;
