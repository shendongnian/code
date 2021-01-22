    WebRequest webRequest = WebRequest.Create(Url);
    using (WebResponse webResponse = webRequest.GetResponse())
    {
        using (Stream responseStream = webResponse.GetResponseStream())
        {
            XmlDocument XmlDoc = new XmlDocument();
            GeoCode oGeoCode = new GeoCode();
            XmlDoc.Load(responseStream);
        }
    }
