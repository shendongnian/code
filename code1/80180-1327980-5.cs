    public static XmlDocument ServiceCall(string url, int service, StringDictionary data)
    {
        HttpWebRequest request = CreateWebRequest(url);
        
        XmlDocument soapEnvelopeXml = GetSoapXml(service, data);
        using (Stream stream = request.GetRequestStream())
        {
            soapEnvelopeXml.Save(stream);
        }
        IAsyncResult asyncResult = request.BeginGetResponse(null, null);
        asyncResult.AsyncWaitHandle.WaitOne();
        string soapResult;
        using (WebResponse webResponse = request.EndGetResponse(asyncResult))
        using (StreamReader rd = new StreamReader(webResponse.GetResponseStream()))
        {
            soapResult = rd.ReadToEnd();
        }
        File.WriteAllText(HttpContext.Current.Server.MapPath("/servicios/" + DateTime.Now.Ticks.ToString() + "assor_r" + service.ToString() + ".xml"), soapResult);
        XmlDocument resp = new XmlDocument();
        resp.LoadXml(soapResult);
        return resp;
    }
