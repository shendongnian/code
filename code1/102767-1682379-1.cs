    private DateTime GetCurrentDateTime()
    {
        WebRequest request = WebRequest.Create(@"http://developer.yahooapis.com/TimeService/V1/getTime?appid=Test");
        request.Proxy = new WebProxy("PROXYSERVERNAME", 8080); // You may or may not need this
        WebResponse response = request.GetResponse();      
  
        Double currentTimeStamp = 0;
        using (Stream stream = response.GetResponseStream())
        {
            using (XmlTextReader xmlReader = new XmlTextReader(stream))
            {
                while (xmlReader.Read())
                {
                    switch (xmlReader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (xmlReader.Name == "Timestamp")
                            {
                                currentTimeStamp = Convert.ToDouble(xmlReader.ReadInnerXml());
                            }
                            break;
                    }
                }
                xmlReader.Close();
            }
        }
        DateTime yahooDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
        return yahooDateTime.AddSeconds(currentTimeStamp).ToUniversalTime();        
    }
