    //make a call to get an auth token
    string token;
    using (var client = new WebClient())
    {
        var values = new NameValueCollection();
        values["grant_type"] = "client_credentials";
        values["client_id"] = "YOUR APP ID";
        values["client_secret"] = "NcOXRwb51joibEfzUuNE04u";
        values["scope"] = "YOUR APP ID/.default";
        var response =
            client.UploadValues("https://login.microsoftonline.com/botframework.com/oauth2/v2.0/token", values);
        var responseString = Encoding.Default.GetString(response);
        var result = JsonConvert.DeserializeObject<ResponseObject>(responseString);
        token = result.access_token;
    }
        
    //you will need to adjust this value for your project.
    //this example for a proxy project so the service url here is
    //just an arbitrary endpoint I was using to send activities to
    activity.ServiceUrl = "http://localhost:4643/api/return";    
    var jsonActivityAltered = JsonConvert.SerializeObject(activity);
    using (var client = new WebClient())
    {
        client.Headers.Add("Content-Type", "application/json");
        client.Headers.Add("Authorization", $"Bearer {token}");
        try
        {
            var btmResponse = client.UploadString("http://localhost:3971/api/messages", jsonActivityAltered);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
