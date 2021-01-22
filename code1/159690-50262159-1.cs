    [TestClass]
        public class HttpTests
        {
            [TestMethod]
            public void TestMethod1()
            {
                var jsObject = (dynamic)new JObject();
                jsObject.html =  "samplehtml.html";
                jsObject.format = "jpeg";
                const string url = "https://mywebservice.com/api";
    
                var result =   GetResponseString(url, jsObject).GetAwaiter().GetResult();
                 File.WriteAllBytes($@"c:\temp\httpresult.{jsObject.format}", result);
            }
    
          
            static async Task<byte[]> GetResponseString(string uri, dynamic jsObj)
            {
                var httpClient = new HttpClient();
                var load = jsObj.ToString();
                var content = new StringContent(load, Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(uri, content);
                var contents = await response.Content.ReadAsByteArrayAsync();
                return contents;
            }
        }
    }
