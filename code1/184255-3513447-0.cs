    bool inPhone = false;
    string landLine = null;
    string fax = null;
    
    using(xml = XmlReader.Create(websiteResultStream, xmlSettings)
    while(xml.Read())
    {
      switch(xml.NodeType)
      {
        case XmlNodeType.Element:
          switch(xml.LocalName)
          {
            case "phone":
              inPhone = true;
              break;
            case "LandLine":
              if(inPhone)
              {
                landLine = xml.ReadElementContentAsString();
                if(fax != null)
                {
                  DoWhatWeWantToDoWithTheseValues(landline, fax);
                  return;
                }
              }
              break;
            case "Fax":
              if(inPhone)
              {
                fax = xml.ReadElementContentAsString();
                if(landLine != null)
                {
                  DoWhatWeWantToDoWithTheseValues(landline, fax);
                  return;
                }
              }
              break;
          }
          break;
        case XmlNodeType.EndElement:
          if(xml.LocalName == "phone")
            inPhone = false;
          break;
      }
    }
