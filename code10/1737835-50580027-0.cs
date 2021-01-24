    using System;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json.Linq;
    using swagger; // my name space from the autorest command, not to be confused with swagger itself.
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
    
            private static async Task GetMyJob()
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
                var response = result.Response;
                Console.WriteLine(response.ToString());
            }
        }
    }
