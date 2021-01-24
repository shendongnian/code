    using (var client = new HttpClient())
    {
        client.BaseAddress = new Uri(Statics.Baseurl); //The base Url is the Http Post request url (base)
        client.DefaultRequestHeaders.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    
        TokenAndId info = new TokenAndId();
        info.Token = User.Identity.GetUserId();
        info.ID = id;
        StringContent content = new StringContent(JsonConvert.SerializeObject(info), Encoding.UTF8, "application/json");
    
        HttpResponseMessage Res = await client.PostAsync("api/Worker/GetDetails", content); //the base address already defined in the client, this is the remaining part of the address
    
        if (Res.IsSuccessStatusCode)
        {
             var response = Res.Content.ReadAsStringAsync().Result;
             worker = JsonConvert.DeserializeObject<Worker>(response);
             output.worker = worker;
         }
     }
