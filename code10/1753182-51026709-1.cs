    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri($"http://localhost/###");
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        using (var content = new MultipartFormDataContent())
        {
            content.Add(new StreamContent(new MemoryStream(image)), "image", "myImage.jpg");
            using (var response = await client.PostAsync($"http://localhost:#####/###/###/###", content).ConfigureAwait(false))
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responseAsString =  response.Content.ReadAsStringAsync().Result;
                    var receiptFromApi = JsonConvert.DeserializeObject<Receipt>(responseAsString);
                    var metadata = new metadata(bilaga)
                    {
                        Value1 = fromApi.Value1.Value,
                        Value2 = fromApi.Value2.Value,
                        Value3 = fromApi.Value3.Value,
                        Value4 = fromApi.Value4.Value
                    };
                    return metadata;
                }
                else
                {
                    throw new InvalidProgramException();
                }
            }
        }
    }
