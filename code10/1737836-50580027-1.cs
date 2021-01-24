    using System;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using swagger;
    using swagger.Models;
    
    namespace CoreClientTest
    {
        [TestClass]
        public class MyTests
        {
            [TestMethod]
            public void TestMethod1()
            {
                try
                {
                     GetMyJob().Wait();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
    
            private static async Task<JobHeader> GetMyJob()
            {
                var tokenRequest = new TokenRequest
                {
                    Username = "myusername",
                    Password = "mypassword"
                };
                var credentials = new TokenCredentials("bearer token");
                var uri = new Uri("https://localhost:44348", UriKind.Absolute);
                var tokenClient = new Track3API(uri, credentials);
                var tokenResponse = await tokenClient.ApiRequestTokenPostWithHttpMessagesAsync(tokenRequest);
                var tokenContent = await tokenResponse.Response.Content.ReadAsStringAsync();
                var tokenString = JObject.Parse(tokenContent).GetValue("token").ToString();
                var creds2 = new TokenCredentials(tokenString);
                var client2 = new Track3API(uri, creds2);
                var result = await client2.ApiJobsByIdGetWithHttpMessagesAsync(1);
                string resultContent = await result.Response.Content.ReadAsStringAsync();
                var job = JsonConvert.DeserializeObject<JobHeader>(resultContent);
                Console.WriteLine(job.JobNumber);
                return job;
    
            }
        }
    }
