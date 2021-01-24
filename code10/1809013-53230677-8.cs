    using (var client = new HttpClient())
    {
         //Setting the base address of the server 
        client.BaseAddress = new Uri("https://sdpondemand.manageengine.com");
        //creating an anonymous object
        var jsonObject = new {
            input_data = new {
                 row_count = 100,
                 start_index = 101
            }
        };
    
        //Converting into the content string
        var content = new StringContent(JsonConvert.SerializeObject(jsonObject), Encoding.UTF8, "application/json");
        //waiting for the post request to complete
        var result = await client.PostAsync("app/itdesk/api/v3/requests", content);
        
        //reading the response string 
        string resultContent = await result.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode)
        {
            //Deserialize your string into custom object here
            var obj = JsonConvert.DeserializeObject<YourDTO>(resultContent);
        }
        else
        {
            //Todo: Log the Exception here
            throw new Exception(contentString);
        }
    }
