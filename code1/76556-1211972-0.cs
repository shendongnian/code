    public bool CheckTwitterCredentials(string UserName, string Password)
    {
        // Assume failure
        bool Result = false;
        // A try except block to handle any exceptions
        try {
            // Encode the user name with password
            string UserPass = Convert.ToBase64String(
                System.Text.Encoding.UTF8.GetBytes(UserName + ":" + Password));
     
            // Create our HTTP web request object
            HttpWebRequest Request = 
                (HttpWebRequest)WebRequest.Create("http://twitter.com/account/verify_credentials.xml");
            // Set up our request flags and submit type
            Request.Method = "GET";
            Request.ContentType = "application/x-www-form-urlencoded";
     
            // Add the authorization header with the encoded user name and password
            Request.Headers.Add("Authorization", "Basic " + UserPass);
            // Use an HttpWebResponse object to handle the response from Twitter
            HttpWebResponse WebResponse = (HttpWebResponse)Request.GetResponse();
            // Success if we get an OK response
            Result = WebResponse.StatusCode == HttpStatusCode.OK;
        } catch (Exception Ex) {
            System.Diagnostics.Debug.WriteLine("Error: " + Ex.Message);
        }
        // Return success/failure
        return Result;
    }
