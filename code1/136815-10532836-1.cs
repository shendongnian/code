    Uri url = new Uri("http://msdn.microsoft.com/en-US/");
    if (url.Scheme == Uri.UriSchemeHttp)
    {
        //Create Request Object
        HttpWebRequest objRequest = (HttpWebRequest)HttpWebRequest.Create(url);
        //Set Request Method
        objRequest.Method = WebRequestMethods.Http.Get;
        //Get response from requested url
        HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
        //Read response in stream reader
        StreamReader reader = new StreamReader(objResponse.GetResponseStream());
        string tmp = reader.ReadToEnd();
        objResponse.Close();
        //Set response data to container
        this.pnlScreen.GroupingText = tmp;
    }
