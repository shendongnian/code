    public void SubmitUserStatus(string username, string password, string tweet)
    {
      // encode the username/password
      string user = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(username + ":" + password));
      // determine what we want to upload as a status
      byte[] bytes = System.Text.Encoding.ASCII.GetBytes("status=" + tweet);
      // connect with the update page
      HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://twitter.com/statuses/update.xml");
      // set the method to POST
      request.Method = "POST";
      request.ServicePoint.Expect100Continue = false;
      // set the authorisation levels
      request.Headers.Add("Authorization", "Basic " + user);
      request.ContentType = "application/x-www-form-urlencoded";
      // set the length of the content
      request.ContentLength = bytes.Length;
      // set up the stream
      Stream reqStream = request.GetRequestStream();
      // write to the stream
      reqStream.Write(bytes, 0, bytes.Length);
      // close the stream
      reqStream.Close();
    }
