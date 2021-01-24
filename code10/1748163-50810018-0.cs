    HttpClient client = new HttpClient();
    client.BaseAddress = new Uri("naseURL");
    
    string url = $"endPoint";
    ObjectContent content = new ObjectContent<List<ContactsDTO>>(objMessage, new JsonMediaTypeFormatter());
    HttpResponseMessage response = client.PostAsync(url, content).Result;
