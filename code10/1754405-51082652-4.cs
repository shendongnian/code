    static Lazy<HttpClient> httpClient = new Lazy<HttpClient>(() => {
        var postURL = "https://search.apicall.com/photographer/customer";
        var token = "token xxxxxxxxxxxxxxxxxxxxx";
        HttpClient client = new HttpClient();
        client.BaseAddress = new Uri(postURL);
        client.DefaultRequestHeaders.Add("Authorization", token);
        return client
    });
    public async Task SendPostAsync(string name, string email, string phone, int photo_count, string event_name, string event_id, string dir_name, int package_type, string video_text, int template_id, string[] favoritesArray)
    {
        var postURL = "https://search.apicall.com/photographer/customer";
        int delivery_method = 2;
        
        string POSTcall = JsonConvert.SerializeObject(new { name, email, phone, photo_count, event_id, event_name, dir_name, package_type, video_text, delivery_method, template_id, favorites = favoritesArray });    
    
        //Send string to log file for debug
        WriteLog(POSTcall);    
    
        StringContent stringContent = new StringContent(POSTcall, UnicodeEncoding.UTF8, "application/json");    
    
        HttpResponseMessage response = await httpClient.Value.PostAsync(new Uri(postURL), stringContent);
        string POSTresponse = await response.Content.ReadAsStringAsync();
        WriteLog(POSTresponse);
    
        //simplified output for debug
        if (POSTresponse.Contains("error") && POSTresponse.Contains("false")) {
            lblStatus.Text = "Error Sending to CL";
        } else {
            lblStatus.Text = "Successfully added to CL";
        }
    }
