    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri(Statics.Baseurl); //The base Url is the Http Post request url (base) eg: http://www.example.com/
        client.DefaultRequestHeaders.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
        Info info = new Info();
        info.fullname = "Name surname";
        info.code = "123465";
        info.code2 = "123465";
        info.code3 = "123465";
        StringContent content = new StringContent(JsonConvert.SerializeObject(info), Encoding.UTF8, "application/json");
    
        HttpResponseMessage Res = await client.PostAsync("api/Worker/GetDetails", content); //the base address already defined in the client, this is the remaining part of the address (example)
    
        if (Res.IsSuccessStatusCode)
        {
             var response = Res.Content.ReadAsStringAsync().Result;
        }
     }
