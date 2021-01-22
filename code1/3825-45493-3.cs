    void ParseURL(string strUrl)
    {
      try
      {
        using (var reader = XmlReader.Create(strUrl))
        {
          while (reader.Read())
          {
            switch (reader.NodeType)
            {
              case XmlNodeType.Element:
                var attributes = new Hashtable();
                var strURI = reader.NamespaceURI;
                var strName = reader.Name;
                if (reader.HasAttributes)
                {
                  for (int i = 0; i < reader.AttributeCount; i++)
                  {
                    reader.MoveToAttribute(i);
                    attributes.Add(reader.Name,reader.Value);
                  }
                }
                StartElement(strURI,strName,strName,attributes);
                break;
                //
                //you can handle other cases here
                //
                //case XmlNodeType.EndElement:
                // Todo
                //case XmlNodeType.Text:
                // Todo
                default:
                break;
              }
            }
          }
          catch (XmlException e)
          {
            Console.WriteLine("error occured: " + e.Message);
          }
        }
      }
    }
