    // .. request created, required params applied
    httpWebRequest.ProtocolVersion = HttpVersion.Version10; // fix 1
    httpWebRequest.KeepAlive = false; // fix 2
    httpWebRequest.Timeout = 1000000000; // fix 3
    httpWebRequest.ReadWriteTimeout = 1000000000; // fix 4
    // .. request processed, data written to request stream
    string strResponse = "";            
    try
    {
        using (WebResponse httpResponse = httpWebRequest.GetResponse()) // error here
            {
                using (Stream responseStream = httpResponse.GetResponseStream())
                {
                    using (StreamReader streamReader = new StreamReader(responseStream))
                        {
                            strResponse = streamReader.ReadToEnd();
                        }
                    }
                }
            }
    catch (WebException exception)
    {
        throw exception;
    }
