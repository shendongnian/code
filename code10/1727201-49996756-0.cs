    using System.Net.Http;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    
    namespace JayGongCosmosDB
    {
        public static class Function2
        {
            [FunctionName("Function1")]
            public static void Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req,
                 [DocumentDB("db", "coll", Id = "id", ConnectionStringSetting = "myCosmosDB")] out dynamic document)
            {
                document = new { Id = "Identifier1", Title = "Some Title" };
            }
        }
    }
