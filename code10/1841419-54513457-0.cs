    public static void CreateJiraRequest(Chat jiraApiObject)
    {
        string url = "https://jira-test.ch.*******.net/rest/api/latest/issue/";
        string user = "peno.ch";
        string password = "****";
    
        var request = (HttpWebRequest)WebRequest.Create(url);
        request.Method = "POST";
        request.ContentType = "application/json";
        request.Credentials = new System.Net.NetworkCredential(user, password);
    
        string data = JsonConvert.SerializeObject(jiraApiObject);
    
        using (var webStream = request.GetRequestStream())
        using (var requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
        {
            requestWriter.Write(data);
        }
    
        try
        {
            var webResponse = request.GetResponse();
            using (var responseReader = new StreamReader(webResponse.GetResponseStream()))
            {
                string response = responseReader.ReadToEnd();
                // Do what you need to do with the response here.
            }
        }
        catch (Exception ex)
        {
            // Handle your exception here
            throw ex;
        }
    }
