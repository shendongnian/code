    var response = (HttpWebResponse)httpRequest.GetResponse();
    using (Stream rs = response.GetResponseStream())
    {
        findContractResponse result = DeserializeResponse<findContractResponse>(rs);
        return result == null ? null : result.@return;
    }
    T DeserializeResponse<T>(Stream stream)
    {
        using (StreamReader reader = new StreamReader(stream))
        {
            Type type = typeof(T);
            XDocument doc = XDocument.Parse(reader.ReadToEnd());
            XElement data = doc.Descendants(XName.Get(type.Name, "http://somewebsite.com/soapService")).FirstOrDefault();
            if(data == null)
            {
                return default(T);
            }
            XmlSerializer ser = new XmlSerializer(type, "http://somewebsite.com/soapService");
            string tmpXml = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + data.ToString();
            using (StringReader stringReader = new StringReader(tmpXml))
            {
                return (T)ser.Deserialize(stringReader);
            }
        }
    }
