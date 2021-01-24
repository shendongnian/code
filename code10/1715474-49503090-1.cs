    static HttpClient httpClient = new HttpClient("appurl");
    public async Task<bool> CheckIfJobIsRunning(){
        httpClient.DefaultRequestHeaders.Accept.Add(
           new MediaTypeWithQualityHeaderValue("application/json"));
        var jobArguments = //Assuming the JSON came from database
            
        var content = new StringContent( jobArguments, Encoding.UTF8, "application/json");
            JobId = 10, 
            Code = "EB430", 
            CostCenter = "XYZ"
        }; 
        var response = await httpClient.PostAsAsync("/jobs/isrunning", content);
        
        var result = await response.Content.ReadAsAsync<bool>();
        return result;
    }
    
