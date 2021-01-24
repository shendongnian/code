    var settings = new ConnectionSettings(new Uri("http://localhost:9200"))
	   .DisableDirectStreaming()
	   .DefaultIndex("sales");
    var client = new ElasticClient(settings);
    var searchResponse = await client.SearchAsync<Sales>(x => x
	   .Size(0)
	   .MatchAll()
    );
    if (searchResponse.ApiCall.ResponseBodyInBytes != null)
    {
       var requestJson = System.Text.Encoding.UTF8.GetString(searchResponse.ApiCall.RequestBodyInBytes);
       Console.WriteLine(JsonConvert.SerializeObject(JsonConvert.DeserializeObject(requestJson), Formatting.Indented));
    }
