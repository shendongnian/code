    private static readonly XmlSerializer secondLevelElementSerializer = 
        new XmlSerializer(typeof(MyXml.SecondLevelElement));
    ...
    XmlReader reader;
    while (reader.Read())
    {
        ...
        switch (reader.Name)
        {
            case "SecondLevelElement":
                {
                     MyXml.SecondLevelElement elem = (MyXml.SecondLevelElement)
                          secondLevelElementSerializer.Deserialize(reader);
                     ...
                } break;
            ...
        }
    }  
  
