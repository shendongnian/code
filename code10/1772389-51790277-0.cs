    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    
    async Task<string> ShowRemoteStringFile(string readUrl){
    
    HttpClient httpClient = new HttpClient();
    httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
    				Convert.ToBase64String(
    					System.Text.ASCIIEncoding.ASCII.GetBytes(
    						string.Format("{0}:{1}", Username, Password))));
    httpClient.DefaultRequestHeaders.Add("Accept", "text/plain; charset=UTF-8");
    var body = new StringContent("your http post body text", Encoding.UTF8, "application/json");
    Task<System.Net.Http.HttpResponseMessage> r = httpClient.PostAsync("YOUR_URL", body);
    // do stuff while waiting for response to come back
    var response = await r; //await the request to return a result from the server 
    var responseContent = response.Content;
    if (response.IsSuccessStatusCode){
    //Do stuff with the response content
    }
    
    }
