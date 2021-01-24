    var client = new HttpClient();
    var content = new StringContent("YOUR LONG STRING", 
                                 System.Text.Encoding.Unicode, 
                                 "application/json");            
    var task = client.PostAsync(restURL, content);
    var str = await task.Result.Content.ReadAsStringAsync();   
