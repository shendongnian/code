    var formatters = new MediaTypeFormatterCollection();
    var jsonFormatter = formatters.OfType<JsonMediaTypeFormatter>().FirstOrDefault();
    //Setup jsonFormatteru using its properties like SerializerSettings
    HttpClient client = new HttpClient();
    var response = await client.GetAsync("http://localhost:58045/api/products/1");
    if (response.IsSuccessStatusCode)
    {
        var result = await response.Content.ReadAsAsync<Product>(formatters);
    }
