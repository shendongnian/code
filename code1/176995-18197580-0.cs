    System.Net.WebRequest request = System.Net.WebRequest.Create(link);
    request.ConnectionGroupName = "MyNameForThisGroup"; 
    ((HttpWebRequest)request).Referer = "http://application.com";
    using (System.Net.WebResponse response = request.GetResponse())
    {
        StreamReader sr = new StreamReader(response.GetResponseStream());
        return sr.ReadToEnd();
    }
