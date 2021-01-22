    var AllSections = 
      from s in xmlDoc.Descendants("section")
      select new
      {
          id = s.Attribute("id").Value,
          themeTitle = s.Element("themeTitle").Value,
          themeText = s.Element("themeText").Value,
          objects = (from  a in AllObjects.Select((Item,Index) => new {Item,Index})
                     join b in s.Item.Descendants("object")
                     on  a.Item.Attribute("accessionNumber").Value equals
                         b.Attribute("accessionNumber").Value
                      //select a
                      select new
                      {
                        //index = insert ordinal id/index of element
                        Index = a.Index,
                        ObjectTitle = a.Element("ObjectTitle").Value,
                        ObjectText = a.Element("textentry").Value,
                      }   
                    )
      };
