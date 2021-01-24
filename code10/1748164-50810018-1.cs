    HttpClient client = new HttpClient();
    client.BaseAddress = new Uri(RemoteURL);
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    string url = $"endPoint";
    ObjectContent content = new ObjectContent<List<ContactsDTO>>(objMessage, new JsonMediaTypeFormatter());
    HttpResponseMessage response = await client.PostAsync(url, content);
