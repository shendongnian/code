    // Create HttpClient
    var client = new HttpClient { BaseAddress = new Uri("http://localhost:8888/") };
    // Assign default header (Json Serialization)
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ApiConstant.JsonHeader));    
    // Make an API call and receive HttpResponseMessage
    var responseMessage = await client.GetAsync("PersonList", HttpCompletionOption.ResponseContentRead);
    // Convert the HttpResponseMessage to string
    var resultArray = await result.Content.ReadAsStringAsync();
    // Deserialize the Json string into type using JsonConvert
    var personList = JsonConvert.DeserializeObject<List<Person>>(resultArray);
