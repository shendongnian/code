    using MongoDB.Bson;
    using MongoDB.Driver;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp2
    {
      class Program
      {
        static void Main(string[] args)
        {
          MainAsync().Wait();
        }
    
        static async Task MainAsync()
        {
          var client = new MongoClient();
          var db = client.GetDatabase("test");
          var entities = db.GetCollection<Entity>("entities");
    
          try
          {
            /*
             * Meaning a serialized structure like:
             * { "K1": [ "V1", "V2" ], "K2": [ "V2", "V3" ] } 
             */
            Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>
            {
              { "K1", new List<string> { "V1", "V3" } },
              { "K2", new List<string> { "V2", "V3" } }
            };
    
            string output = JsonConvert.SerializeObject(dict);
            Console.WriteLine(output);
    
            /*
             *  Meaning a serialized structure like:
             *  [
             *    { "K1": [ "V1", "V2" ] },
             *    { "K2": [ "V2", "V3" ] }
             *  ]
             */
            List<Dictionary<string, List<string>>> alt = new List<Dictionary<string, List<string>>>
            {
              {  new Dictionary<string, List<string>> { { "K1", new List<string> {  "V1", "V3" } } } },
              {  new Dictionary<string, List<string>> { { "K2", new List<string> {  "V2", "V3" } } } },
            };
    
            string output2 = JsonConvert.SerializeObject(alt);
            Console.WriteLine(output2);
    
            // Build query from 'dict' form
            List<FilterDefinition<Entity>> orConditions = new List<FilterDefinition<Entity>>();
            foreach (KeyValuePair<string, List<string>> entry in dict)
            {
              orConditions.Add(
                Builders<Entity>.Filter.Eq(p => p.SharedId, entry.Key) &
                Builders<Entity>.Filter.Where(p => entry.Value.Contains(p.Tag))
              );
            };
            var query1 = Builders<Entity>.Filter.Or(orConditions);
            /*
             * Builds -
              {
                "$or" : [
                    {
                      "SharedId" : "K1",
                      "Tag" : { "$in" : [ "V1", "V3" ] }
                    },
                    {
                      "SharedId" : "K2",
                      "Tag" : { "$in" : [ "V2", "V3" ] }
                    }
                ]
              }
            */
            Console.WriteLine("Output 1");
            var cursor1 = await entities.Find(query1).ToListAsync();
            foreach (var doc in cursor1)
            {
              Console.WriteLine(doc.ToBsonDocument());
            }
    
            // Build the query from 'alt' form
            orConditions = new List<FilterDefinition<Entity>>(); // clear the list
    
            foreach(var item in alt)
            {
              foreach(KeyValuePair<string,List<string>> entry in item)
              {
                orConditions.Add(
                  Builders<Entity>.Filter.Eq(p => p.SharedId, entry.Key) &
                  Builders<Entity>.Filter.Where(p => entry.Value.Contains(p.Tag))
                );
              }
            }
    
            var query2 = Builders<Entity>.Filter.Or(orConditions);
    
            /* Serializes just the same */
            Console.WriteLine("Output 2");
            var cursor2 = await entities.Find(query2).ToListAsync();
            foreach (var doc in cursor2)
            {
              Console.WriteLine(doc.ToBsonDocument());
            }
    
    
          }
          catch (Exception ex)
          {
            Console.WriteLine(ex);
          }
    
        }
      }
    
      public class Entity
      {
        public int id;
        public string SharedId { get; set; }
        public string Tag { get; set; }
      }
    }
