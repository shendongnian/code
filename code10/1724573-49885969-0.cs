     using System;
     using System.Threading.Tasks;
     using Newtonsoft.Json.Linq;
     using RestSharp;
     namespace ImNotSoTired
     {
        class Program
        {
             static void Main(string[] args)
             {
                 DoThingsAsync().Wait();
                 Console.ReadLine();
             }
             private static async Task<object> DoThingsAsync()
             {
                 RestClient client = new RestClient("http://jsonplaceholder.typicode.com");
                 var response = client.Execute(new RestRequest("users"));
                 JArray users = JArray.Parse(response.Content);
                 var user = (JObject)users[0];
                 foreach (JProperty property in user.Properties())
                 {
                     Console.WriteLine(property.Name + " - " + property.Value);
                 }
                 return null;
             }
         }
    }
