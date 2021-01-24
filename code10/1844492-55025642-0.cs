    ---------------------------------------------------
    
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;
    using System.Threading.Tasks;
    namespace FirstDocDB
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                var connectionString = "mongodb://pulkit:password@ClusterID:27017/?ssl=true&sslVerifyCertificate=true&replicaSet=rs0";
                var client = new MongoClient(connectionString);
                var database = client.GetDatabase("test");
                var collection = database.GetCollection("stuff");
                var document = collection.Find(new BsonDocument()).FirstOrDefault();
                Console.WriteLine(document.ToString());
            }
        }
    }
    
    ---------------------------------------------------
