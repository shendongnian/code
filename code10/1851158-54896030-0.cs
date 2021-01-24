    const string ELASTIC_SERVER = "http://localhost:9200";
    const string DEFAULT_INDEX = "my_index";
    const int NUM_RECORDS = 1000;
    
    private static readonly Random _random = new Random();
    private static readonly IReadOnlyList<string> Tags = 
        new List<string>
        {
            "catfish",
            "tractor",
            "racecar",
            "airplane",
            "chicken",
            "goat",
            "pig",
            "horse",
            "goose",
            "duck"
        };
    
    private static ElasticClient _client;
    
    private static void Main()
    {
        var pool = new SingleNodeConnectionPool(new Uri(ELASTIC_SERVER));
    
        var settings = new ConnectionSettings(pool)
            .DefaultIndex(DEFAULT_INDEX);
    
        _client = new ElasticClient(settings);
    
        Console.WriteLine("Rebuild index? (y):");
        var answer = Console.ReadLine().ToLower();
        if (answer == "y")
        {
            RebuildIndex();
            AddToIndex();
        }
    
        Console.WriteLine();
        Console.WriteLine("Getting a Thing...");
        var aThingId = GetARandomThingId();
    
        Console.WriteLine();
        Console.WriteLine("Looking for something similar to document with id " + aThingId);
        Console.WriteLine();
        Console.WriteLine();
    
        GetMoreLikeAThing(aThingId);
    }
    
    public class MyThing
    {
        public List<string> Tags { get; set; }
    }
    
    private static string GetARandomThingId()
    {
        var firstdocQuery = _client
            .Search<MyThing>(s =>
                s.Size(1)
                .Query(q => q
                    .FunctionScore(fs => fs
                        .Functions(fn => fn
                            .RandomScore(rs => rs
                                .Seed(DateTime.Now.Ticks)
                                .Field("_seq_no")
                            )
                        )
                    )
                )
            );
    
        if (!firstdocQuery.IsValid || firstdocQuery.Hits.Count == 0) return null;
    
        var hit = firstdocQuery.Hits.First();
        Console.WriteLine($"Found a thing with id '{hit.Id}' and tags: {string.Join(", ", hit.Source.Tags)}");
        return hit.Id;
    }
    
    private static void GetMoreLikeAThing(string id)
    {
        var result = _client.Search<MyThing>(s => s
            .Index(DEFAULT_INDEX)
            .Query(esQuery => esQuery 
                .MoreLikeThis(mlt => mlt
                        .Include(true)
                        .Fields(f => f.Field(ff => ff.Tags))
                        .Like(l => l.Document(d => d.Id(id)))
                        .MinTermFrequency(1)
                        .MinDocumentFrequency(1)
                ) && !esQuery
                .Ids(ids => ids
                    .Values(id)
                )
            )
        );
    
        if (result.IsValid)
        {
            if (result.Hits.Count > 0)
            {
                Console.WriteLine("These things are similar:");
                foreach (var hit in result.Hits)
                {
                    Console.WriteLine($"   {hit.Id}: {string.Join(", ", hit.Source.Tags)}");
                }
            }
            else
            {
                Console.WriteLine("No similar things found.");
            }
    
        }
        else
        {
            Console.WriteLine("There was an error running the ES query.");
        }
    
        Console.WriteLine();
        Console.WriteLine("Enter (y) to get another thing, or anything else to exit");
        var y = Console.ReadLine().ToLower();
    
        if (y == "y")
        {
            var aThingId = GetARandomThingId();
            GetMoreLikeAThing(aThingId);
        }
    
        Console.WriteLine();
        Console.WriteLine("Any key to exit...");
    
    }
    
    private static void RebuildIndex()
    {
        var existsResponse = _client.IndexExists(DEFAULT_INDEX);
        if (existsResponse.Exists) //delete existing mapping (and data)
        {
            _client.DeleteIndex(DEFAULT_INDEX);
        }
    
        var rebuildResponse = _client.CreateIndex(DEFAULT_INDEX, c => c
            .Settings(s => s
                .NumberOfShards(1)
            )
            .Mappings(m => m       
                .Map<MyThing>(mm => mm.AutoMap())
            )
        );
    }
    
    private static void AddToIndex()
    {
        var bulkAllObservable = _client.BulkAll(GetMyThings(), b => b
            .RefreshOnCompleted()
            .Size(1000));
            
        var waitHandle = new ManualResetEvent(false);
        Exception exception = null;
      
        var bulkAllObserver = new BulkAllObserver(
            onNext: r =>
            {
                Console.WriteLine($"Indexed page {r.Page}");
            },
            onError: e => 
            {
                exception = e;
                waitHandle.Set();
            },
            onCompleted: () => waitHandle.Set());
            
        bulkAllObservable.Subscribe(bulkAllObserver);
            
        waitHandle.WaitOne();
        
        if (exception != null)
        {
            throw exception;
        }
    }
    
    private static IEnumerable<MyThing> GetMyThings()
    {
        for (int i = 0; i < NUM_RECORDS; i++)
        {
            var randomTags = Tags.OrderBy(o => Guid.NewGuid().ToString())
                .Take(_random.Next(0, Tags.Count))
                .OrderBy(t => t)
                .ToList();
                
            yield return new MyThing { Tags = randomTags };
        }
    }
