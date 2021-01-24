        #r "Newtonsoft.Json"
        using System;
        using System.Text;
        using System.Net.Http;
        using System.Net.Http.Headers;
        using Newtonsoft.Json;
        public static async Task Run(Stream myBlob, Stream outputBlob, TraceWriter log)
        {
         string subscriptionKey = "YOUR KEY HERE";
         string uriBase = "https://westcentralus.api.cognitive.microsoft.com/vision/v1.0/recognizeText";
         int ID = 0;
         String outputJSON = "json string to be written onto blob";
         HttpClient client = new HttpClient();
         client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
         string requestParameters = "handwriting=true";
         string uri = uriBase + "?" + requestParameters;
         HttpResponseMessage response = null;
         string operationLocation = null;
         HttpContent content = new StreamContent(myBlob);
         content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
         response = await client.PostAsync(uri, content);
         if (response.IsSuccessStatusCode)
            operationLocation = response.Headers.GetValues("Operation-Location").FirstOrDefault();
         else
         {
            log.Info("\nError:\n");
            log.Info((await response.Content.ReadAsStringAsync()));
            return;
          }
          string contentString;
          ...
          ...
          System.Threading.Thread.Sleep(1000);
          response = await client.GetAsync(operationLocation);
          contentString = await response.Content.ReadAsStringAsync();
          RootObject jObj = JsonConvert.DeserializeObject<RootObject>(contentString);
        
          log.Info(outputJSON); // at this point outputjson has the info needed to write onto the new blob
 
          byte[] data = Encoding.ASCII.GetBytes(outputJSON);
          outputBlob.Write(data,0,data.Length);
        }
