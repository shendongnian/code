    using Newtonsoft.Json.Linq;
    using System;
    using System.Linq;
    namespace ConsoleApp1
    {
      class Program
      {
        static void Main(string[] args)
        {
            string jsonString = "{\"URL\": \"rest/zapi/latest/cycle?projectId=##projectId##&versionId=##versionId##\",\"Method\": \"GET\",\"Parameters\": {\"1\": {\"VersionName\": \"Custom Pipes Development\",\"TestCycleName\": \"SetMaxFutureDateFromCustomerField_Mobile\"},\2"\": {\"VersionName\": \"Recurring payments 1.5\",\"TestCycleName\": \"Internet Full Regression Pack - Mobile\"}}}";
            
            var parameters = JObject.Parse(jsonString)["Parameters"];
            foreach (var item in parameters.OfType<JProperty>())
            {
                var innerObject = JObject.Parse(item.Value.ToString())["TestCycleName"];
                Console.WriteLine(innerObject.ToString());
            }
            Console.ReadLine(); 
        }
      }
    }
