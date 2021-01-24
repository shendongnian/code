    private static async Task SendCustomObject()
    {
        var controllerName = "BasicApi";
        var basicClientApi = string.Format("http://localhost:5100/api/{0}", controllerName);
    
        using (var httpClient = new HttpClient()){
    
            var packetData = new TestPacket();
            var jsonObj = new { json = packetData };
    
            var json = JsonConvert.SerializeObject(jsonObj); // no need to call `JObject.FromObject`
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
    
            var response = await httpClient.PostAsync(basicClientApi, content);                    
    
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var rawResponse = await response.Content.ReadAsStringAsync();                        
    
                JObject o = JObject.Parse(rawResponse);
                Console.WriteLine(o.ToString());    
            }
        }
    }
    
    namespace myApp.Controllers
    {
        [Route("api/[controller]")]
        public class BasicApiController : Controller
        {    
    
          [HttpPost]    
          // don't ask for a string, ask for the model you are expecting to recieve
          public JsonResult Post(Models.TestPacket json)
          {                
               return Json(new { result = true });
          }
        }
     }
