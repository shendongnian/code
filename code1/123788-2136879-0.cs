    ASCIIEncoding encoding = new ASCIIEncoding();
    string postData = "Field1=VALUE1&JSPName=GIN";
    byte[] data = encoding.GetBytes(postData);
    // Prepare web request...
    HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create("https://XXX/");
    myRequest.Method = "POST";
    myRequest.ContentType = "text/html";
    myRequest.ContentLength = data.Length;
    string result;
    using (WebResponse response = myRequest.GetResponse())
    {
        using (var reader = new StreamReader(myRequest.GetResponseStream()))
        {
            result = reader.ReadToEnd();
        }
    }
