    XDocument xmlDoc = XDocument.Load(HttpContext.Current.Server.MapPath("data.xml"));
    var items = (from item in xmlDoc.Descendants("item")
                where item.Element("itemID").Value == itemID
                select item).ToList();
             foreach (var item in items)
             {
                    item.Element("itemID").Value=NewValue;
                    bool.Parse(item.Element("isGadget").Value)=Newvalue;
                    item.Element("name").Value=Newvalue;
                    item.Element("text1").Value=Newvalue;
             }
    xmlDoc.Save(HttpContext.Current.Server.MapPath("data.xml"));
