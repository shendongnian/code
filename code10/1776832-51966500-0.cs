    using (WebClient Client = InitWebClient())
    {
        
        List<MyJsonObject> Items = new List<MyJsonObject>();
        // The following could easily be made into a for loop, etc:
        MyJsonObject Item1 = new MyJsonObject() {
            Id = 0,
            Name = "John"
        };
        Items.Add(Item1);
        MyJsonObject Item2 = new MyJsonObject() {
            Id = 1,
            Name = "James"
        };
        Items.Add(Item2);
    
        string Json = Newtonsoft.Json.JsonConvert.SerializeObject(Items)
        Client.Headers[HttpRequestHeader.ContentType] = "application/json";
        Client.UploadValues("/api/example", "POST", Json);
    
    }
