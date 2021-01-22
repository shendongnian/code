    protected override System.Net.WebRequest GetWebRequest(Uri uri)
    {
        System.Net.WebRequest request = base.GetWebRequest(uri);          
        string auth = "Basic " + Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(this.Credentials.GetCredential(uri, "Basic").UserName + ":" + this.Credentials.GetCredential(uri, "Basic").Password));
        request.Headers.Add("Authorization", auth);
        return request;
    }
