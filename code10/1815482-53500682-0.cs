    XmlSerializer serializer = new XmlSerializer(typeof(TResponse));
    TResponse result;
    string content = response.Content.Replace(" xmlns=\"urn:ebay:apis:eBLBaseComponents\"", "");
    using (TextReader reader = new StringReader(content))
    {
      result = (TResponse)serializer.Deserialize(reader);
    }
