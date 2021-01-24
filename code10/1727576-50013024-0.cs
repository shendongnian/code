    // Following is the key value pairs (data) which we need to send to server via API.
    Dictionary<string, string> jsonValues = new Dictionary<string, string>();
    jsonValues.Add("username", "testuser");
    jsonValues.Add("password", "XXXXXXXXXX"); // better to encrypt passwod before sending to API.
    
    HttpClient client = new HttpClient();
    
    // Used Newtonsoft.Json library to convert object to json string. It is available in Nuget package.
    StringContent sc = new StringContent(JsonConvert.SerializeObject(jsonValues), UnicodeEncoding.UTF8, "application/json");
    HttpResponseMessage response = await client.PostAsync(webAddress, sc);
    
    string content = await response.Content.ReadAsStringAsync();
    Console.WriteLine("Result: " + content);
    
    
