    public async Task<String> GetData()
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(Statics.Baseurl); 
            //The base Url is the Http Post request url (base) eg: http://www.example.com/
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        
            Info info = new Info();
            info.fullname = "Name surname";
            info.code = "123465";
            info.code2 = "123465";
            info.code3 = "123465";
    
            //JsonCOnvert.SerilizeObject() will convert your custom class to JSON
            StringContent content = new StringContent(JsonConvert.SerializeObject(info), Encoding.UTF8, "application/json");
            
            //the base address already defined in the client
            //This is the remaining part of the address.
            //We are passing the JSON value to the HTTP POST here.
            HttpResponseMessage Res = await client.PostAsync("api/Worker/GetDetails", content); 
        
            if (Res.IsSuccessStatusCode)
            {
                 var response = Res.Content.ReadAsStringAsync().Result;
                 return response;
            }
            else
            {
                 return "No_Data"; 
            }
         }
    }
