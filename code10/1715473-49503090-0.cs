    static HttpClient httpClient = new HttpClient("appurl");
    public async Task<bool> CheckIfJobIsRunning(){
       
       httpClient.DefaultRequestHeaders.Accept.Add(new 
            MediaTypeWithQualityHeaderValue("application/json"));
        var jobArguments = new { 
            JobId = 10, 
            Code = "EB430", 
            CostCenter = "XYZ"
        }; //Assuming the arguments came from database
        var result = await httpClient.PostAsJsonAsync("/jobs/isrunning", jobArguments);
        
        var model = await result.Content.ReadAsAsync<{Your response Type Here}>();
        return model.SomeBooleanProperty;
    }
