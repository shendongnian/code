    void MyFunction(string url)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.UserAgent = ".NET Framework Test Client";
        request.Accept = "text/html";
        Logger.WriteMyLog("application/x-www-form-urlencoded");
        // execute the request
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            // we will read data via the response stream
            Stream resStream = response.GetResponseStream();
            StreamReader streamReader = new StreamReader(
                                          resStream,
                                          Encoding.GetEncoding(response.CharacterSet)
                                        );
            httpData = streamReader.ReadToEnd();
        }
    }
