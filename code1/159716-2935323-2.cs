    [WebMethod]
    public void Reports(string xml, string typeName)
    {
      XmlSerializer xs = new XmlSerializer(Type.GetType(typeName));
      object obj = xs.Deserialize(new StringReader(xml));
      // use the deserialize object
    }
