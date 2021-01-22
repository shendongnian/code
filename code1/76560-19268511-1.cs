    public bool isTwitterValid(string username, string password)
    {
        try
        {
            string user = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(username + ":" + password));
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://twitter.com/statuses/verify.xml");
    
            request.Method = "POST";
            request.ServicePoint.Expect100Continue = false;
            request.Headers.Add("Authorization", "Basic " + user);
            request.ContentType = "application/x-www-form-urlencoded";
            WebResponse response = request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string responseString = reader.ReadToEnd();
            reader.Close();
        }
        catch (Exception ex)
        {
            if (ex.Message.Contains("404")) { return true; }
        }
        return false;
    }
