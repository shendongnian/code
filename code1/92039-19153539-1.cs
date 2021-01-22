    XDocument xmlDoc = XDocument.Load(HttpContext.Current.Server.MapPath("data.xml"));
                 foreach (var item in (from item in xmlDoc.Descendants("item")
                    where item.Element("itemID").Value == itemID
                    select item).ToList())
                 {
                        item.Element("itemID").Value=NewValue;
                        bool.Parse(item.Element("isGadget").Value)=Newvalue;
                        item.Element("name").Value=Newvalue;
                        item.Element("text1").Value=Newvalue;
                 }
        xmlDoc.Save(HttpContext.Current.Server.MapPath("data.xml"));
