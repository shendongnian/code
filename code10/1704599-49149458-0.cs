    using (TextReader textReader = new StreamReader(fileName))
      {
        using (XmlTextReader reader = new XmlTextReader(textReader))
          {                                   
           reader.Namespaces = false;
     XmlSerializer serializer = new XmlSerializer(typeof("YourXmlClassType"));
              parseData = ("YourXmlClassType")serializer.Deserialize(reader);
          }
      }
