    public string get_secure_webpage(string url, string username, string password)
        {
            WebRequest myWebRequest = WebRequest.Create(url);
            NetworkCredential networkCredential = new NetworkCredential(username, password);
            myWebRequest.Credentials = networkCredential;
...
