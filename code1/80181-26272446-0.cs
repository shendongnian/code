    public static HttpStatusCode CallWebService(string webWebServiceUrl, 
                                                string webServiceNamespace, 
                                                string methodName, 
                                                Dictionary<string, string> parameters, 
                                                out string responseText)
    {
        const string soapTemplate = 
    @"<?xml version=""1.0"" encoding=""utf-8""?>
    <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" 
       xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" 
       xmlns:soap=""http://www.w3.org/2003/05/soap-envelope"">
      <soap:Body>
        <{0} xmlns=""{1}"">
          {2}    </{0}>
      </soap:Body>
    </soap:Envelope>";
        var req = (HttpWebRequest)WebRequest.Create(webWebServiceUrl);
        req.ContentType = "application/soap+xml;";
        req.Method = "POST";
        string parametersText;
        if (parameters != null && parameters.Count > 0)
        {
            var sb = new StringBuilder();
            foreach (var oneParameter in parameters)
                sb.AppendFormat("  <{0}>{1}</{0}>\r\n", oneParameter.Key, oneParameter.Value);
            parametersText = sb.ToString();
        }
        else
        {
            parametersText = "";
        }
        string soapText = string.Format(soapTemplate, methodName, webServiceNamespace, parametersText);
        using (Stream stm = req.GetRequestStream())
        {
            using (var stmw = new StreamWriter(stm))
            {
                stmw.Write(soapText);
            }
        }
        var responseHttpStatusCode = HttpStatusCode.Unused;
        responseText = null;
        using (var response = (HttpWebResponse)req.GetResponse())
        {
            responseHttpStatusCode = response.StatusCode;
            if (responseHttpStatusCode == HttpStatusCode.OK)
            {
                int contentLength = (int)response.ContentLength;
                if (contentLength > 0)
                {
                    int readBytes = 0;
                    int bytesToRead = contentLength;
                    byte[] resultBytes = new byte[contentLength];
                    using (var responseStream = response.GetResponseStream())
                    {
                        while (bytesToRead > 0)
                        {
                            // Read may return anything from 0 to 10. 
                            int actualBytesRead = responseStream.Read(resultBytes, readBytes, bytesToRead);
                            // The end of the file is reached. 
                            if (actualBytesRead == 0)
                                break;
                            readBytes += actualBytesRead;
                            bytesToRead -= actualBytesRead;
                        }
                        responseText = Encoding.UTF8.GetString(resultBytes);
                        //responseText = Encoding.ASCII.GetString(resultBytes);
                    }
                }
            }
        }
        // standard responseText: 
        //<?xml version="1.0" encoding="utf-8"?>
        //<soap:Envelope xmlns:soap="http://www.w3.org/2003/05/soap-envelope" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
        //    <soap:Body>
        //        <SayHelloResponse xmlns="http://tempuri.org/">
        //            <SayHelloResult>Hello</SayHelloResult>
        //        </SayHellorResponse>
        //    </soap:Body>
        //</soap:Envelope>
        if (!string.IsNullOrEmpty(responseText))
        {
            string responseElement = methodName + "Result>";
            int pos1 = responseText.IndexOf(responseElement);
            if (pos1 >= 0)
            {
                pos1 += responseElement.Length;
                int pos2 = responseText.IndexOf("</", pos1);
                if (pos2 > pos1)
                    responseText = responseText.Substring(pos1, pos2 - pos1);
            }
            else
            {
                responseText = ""; // No result
            }
        }
        return responseHttpStatusCode;
    }
