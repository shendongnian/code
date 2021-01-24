    var defaultIndex = "default-index";
    var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
    var settings = new ConnectionSettings(pool)
        .DefaultMappingFor<DataEntity>(m => m
			.IndexName(defaultIndex)
			.TypeName("_doc")
		)
        .DisableDirectStreaming()
        .PrettyJson()
        .OnRequestCompleted(callDetails =>
        {
            if (callDetails.RequestBodyInBytes != null)
            {
                Console.WriteLine(
                    $"{callDetails.HttpMethod} {callDetails.Uri} \n" +
                    $"{Encoding.UTF8.GetString(callDetails.RequestBodyInBytes)}");
            }
            else
            {
                Console.WriteLine($"{callDetails.HttpMethod} {callDetails.Uri}");
            }
            Console.WriteLine();
            if (callDetails.ResponseBodyInBytes != null)
            {
                Console.WriteLine($"Status: {callDetails.HttpStatusCode}\n" +
                         $"{Encoding.UTF8.GetString(callDetails.ResponseBodyInBytes)}\n" +
                         $"{new string('-', 30)}\n");
            }
            else
            {
                Console.WriteLine($"Status: {callDetails.HttpStatusCode}\n" +
                         $"{new string('-', 30)}\n");
            }
        });
    var client = new ElasticClient(settings);
