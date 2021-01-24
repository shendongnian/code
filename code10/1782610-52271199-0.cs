    public string MakeException()
    
    {
    
        try
        {
            int zipcode = int.Parse("123er");
        }
        catch (Exception ex)
        {
    
            DateTime dt = DateTime.UtcNow;
            string timeFormat = dt.ToString("s"); 
    
            telemetry.TrackException(ex);
            telemetry.Flush();
            System.Threading.Thread.Sleep(TimeSpan.FromMinutes(5));  // in runtime, need to wait for the result populated           
                            
            string operation_id = System.Diagnostics.Activity.Current.RootId; //get the operation_id, will use it in the query string
    
            string api = "https://api.applicationinsights.io/v1/apps/your_application_id/query?";
            string query = @"query=exceptions | where timestamp >= datetime(""" + timeFormat + @""")";
            query += " | where operation_Id == " + "\"" + operation_id + "\"";
            api += query;
    
            string apikey = "your api key";
    
            //call the REST API
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("x-api-key", apikey);
            var req = string.Format(api);
            HttpResponseMessage response = client.GetAsync(req).Result;
    
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsStringAsync().Result; // return a json string, you can parse it to get the ItemId
            }
            else
            {
                return response.ReasonPhrase;
            }
    
    
        }
        
        return "ok";
    }
