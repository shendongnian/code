    private static void Main()
    {
        var defaultIndex = "documents";
        var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
    
        var settings = new ConnectionSettings(pool, new InMemoryConnection())
            .DefaultIndex(defaultIndex)
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
        
        var pageSize = 20;
        var currentPageIndex = 0;  
        string search = "foo";
        
        
        var searchResponse = client.Search<DocumentElasticModel>(s => s
            .Size(pageSize)
            .Skip(currentPageIndex * pageSize)
            .Sort(ss => ss
                .Descending(SortSpecialField.Score)
            )
            .Source(sf => sf
                .Includes(i => i
                    .Fields(f => f.TopLevelMessage)
                )
            )
            .Query(q => q
                .Nested(c => c
                    .Name("named_query")
                    .Boost(1.1)
                    .InnerHits(i => i.Explain())
                    .Path(p => p.PerguntasRespostas)
                    .Query(nq => nq
                        .MultiMatch(m => m
                            .Fields(f => f
                                .Field(ff => ff.PerguntasRespostas.First().Message)
                            ) 
                            .Query(search)
                        )
                    )
                    .IgnoreUnmapped()
                )
            )
        );
    }
    
    
    public class DocumentElasticModel 
    {
        public string TopLevelMessage { get; set; }
        
        public IEnumerable<PerguntasRespostas> PerguntasRespostas {get;set;}
    }
    
    public class PerguntasRespostas
    {
        public string Message { get; set; }  
    }
