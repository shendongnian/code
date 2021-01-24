    using System;
    using Nest;
    using Nest.JsonNetSerializer;
    using Newtonsoft.Json;
    namespace TestIndexing
    {
      class Program
      {
        static void Main(string[] args)
        {
          var indexName = "geodocument";
          var connectionPool = new Elasticsearch.Net.SniffingConnectionPool(new Uri[] { new Uri("http://localhost:9200") });
          var connectionSettings = new Nest.ConnectionSettings(connectionPool);
          connectionSettings.DefaultIndex(indexName);
          connectionSettings.DisableDirectStreaming();
          var elasticClient = new ElasticClient(connectionSettings);
          Func<TypeMappingDescriptor<GeoDocument>, ITypeMapping> typeMapping = m => m
            .Dynamic(false)
            .Properties(ps => ps
              .Keyword(k => k
                .Name(n => n.DocId))
              .GeoShape(g => g
                .PointsOnly(false)
                .Name(o => o.GeoField)));
          elasticClient.CreateIndex(new CreateIndexDescriptor(indexName).Mappings(ms => ms.Map(typeMapping)));
          var polygon = "{\"type\":\"Polygon\",\"coordinates\":[[[5.856956,51.002753],[5.856928,51.002771],[5.856687,51.002853],[5.856956,51.002753]]]}";
          var document = new GeoDocument()
          {
            DocId = "1",
            GeoField = JsonConvert.DeserializeObject<object>(polygon),
          };
          var indexResponse = elasticClient.IndexDocument(document);
          Console.WriteLine(indexResponse.DebugInformation);
      
          elasticClient.DeleteIndex(new DeleteIndexRequest(indexName));
          Console.ReadKey();
        }
        [Nest.ElasticsearchType(Name = "geoDocument", IdProperty = "DocId")]
        public class GeoDocument
        {
          [Nest.Keyword(Name = "DocId")]
          public string DocId { get; set; }
          [Nest.GeoShape(Name = "GeoField")]
          public object GeoField { get; set; }
        }
      }
    }
