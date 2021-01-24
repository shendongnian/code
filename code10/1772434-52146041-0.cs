    public class Test
    {
     private const string URL_requests = "https://api.applicationinsights.io/v1/apps/your-application-id/metrics/requests/count?timespan=PT6H";
    
     public string GetRequestsCount()
            {
                // in step 1, you get this api key
                string apikey = "flk2bqn1ydur57p7pa74yc3aazhbzf52xbyxthef";
                
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("x-api-key", apikey);
                var req = string.Format(URL_requests);
                HttpResponseMessage response = client.GetAsync(req).Result;
                if (response.IsSuccessStatusCode)
                {
                    // you can get the request count here
                    return response.Content.ReadAsStringAsync().Result;
                }
                else
                {
                    return response.ReasonPhrase;
                }
            }
    }
