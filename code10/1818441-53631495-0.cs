    using System.Net;
    using System.IO;
    
    public static async Task<HttpResponseMessage> Run(HttpRequestMessage req, TraceWriter log)
    {
        log.Info("Blah Blah Blah");
        log.Info("==============");
    
        try
            {
                await Run_Function();
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    log.Info("Error: " + e.Message);
                }
            }
     
    
         return req.CreateResponse(HttpStatusCode.OK, "OK");
    }
    
     private static Task Run_Function()
        {
        // I can either use service account or supply api key.
        // How do I read a JSON file from Azure function?
          using (FileStream fs = new FileStream(@"your_json", FileMode.Open))
            {
                    // then I can Get data and display results.                
            }
        return null;
        }
