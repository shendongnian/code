    var list = new XElement("itemlist");
    foreach (KeyValuePair<string, item> it in dictionary_items)
    {                           
        list.Add(new XElement("item",
                               new XAttribute("article", it.Key),
                               new XAttribute("quantity", it.Value.quantity),
                               new XAttribute("price", it.Value.price)
                            )));
    }
                        
    XDocument xDoc = new XDocument(list);
    xDoc.Save("C:/Users/User/Desktop/XMLOutput.xml");
