    var AllSections = from s in xmlDoc.Descendants("section")
                                      .Select((Item, Index) => new { Item, Index })
                      select new
                      {
                          index = s.Index, 
                          id = s.Item.Attribute("id").Value,
                          themeTitle = s.Item.Element("themeTitle").Value,
                          themeText = s.Item.Element("themeText").Value,
                          objects = (from  a in AllObjects 
                                     join b in s.Item.Descendants("object")
                                     on  a.Attribute("accessionNumber").Value equals
                                         b.Attribute("accessionNumber").Value
                                      //select a
                                      select new
                                       {
                                        //index = insert ordinal id/index of element
                                        ObjectTitle = a.Element("ObjectTitle").Value,
                                        ObjectText = a.Element("textentry").Value,
                                        }
                                         )
                      };
