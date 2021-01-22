    //Common testing requirement. If you are consuming an API in a sandbox/test region, uncomment this line of code ONLY for non production uses.
    //System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
      
    //Be sure to run "Install-Package Microsoft.Net.Http" from your nuget command line.
    using System;
    using System.Net.Http;
    
    var baseAddress = new Uri("https://api.ipdata.co/78.8.53.5");
     
    using (var httpClient = new HttpClient{ BaseAddress = baseAddress })
    {
      
      httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");
        
      using(var response = await httpClient.GetAsync("undefined"))
      {
      
            string responseData = await response.Content.ReadAsStringAsync();
      }
    }
