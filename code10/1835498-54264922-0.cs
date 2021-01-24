    public class RawDocument
    {
    
        [PropertyName("duration")]
        public long Duration { get; set; }
    
        [PropertyName("group_id")]
        public string GroupId { get; set; }
    
        [PropertyName("var_time")]
        public DateTime Vartime { get; set; }
    
        [PropertyName("var_name")]
        public string Varname { get; set; }
    
    }
    
    static void Main(string[] args)
    {
    
        var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
    
        var settings = new ConnectionSettings(pool)
            .DefaultMappingFor<RawDocument>(m => m
                  .IndexName("test_index")
                  .TypeName("doc"));
    
        var searchResponse = client.Search<RawDocument>();
    
        var numberOfSlices = 4;
    
    
        var scrollAllObservable = client.ScrollAll<RawDocument>("3m", numberOfSlices)
            .Wait(TimeSpan.FromMinutes(5), onNext: s =>
        {
    
            var docs = s.SearchResponse.DebugInformation;
            var documents = s.SearchResponse.Hits;
    
            foreach (var document in documents)
                {
                        // do something with this set of documents
                        // business logic to load into the database.
    
                    MessageBox.Show("document.Id=" + document.Id);
                    MessageBox.Show("document.Score=" + document.Score);
                    MessageBox.Show("document.Source.duration=" + document.Source.duration);
                    MessageBox.Show("document.Source.var_time=" + document.Source.var_time);
                    MessageBox.Show("document.Source.var_name=" + document.Source.var_name);
                    MessageBox.Show("document.Type=" + document.Type);
                    MessageBox.Show("document.Index=" + document.Index);
            }
            });
    
    }
