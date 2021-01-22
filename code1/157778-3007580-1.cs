       XDocument doc = XDocument.Load(Server.MapPath("~/xml/gallery.xml")); 
                IEnumerable<XElement> items = from item in doc.Descendants("item")
                                              orderby Convert.ToDateTime(item.Attribute("lastChanges").Value) descending
                                              where int.Parse(item.Attribute("galleryID").Value) == 0 && bool.Parse(item.Attribute("visible").Value) != false
                                              select item;
    
                rptTest.DataSource = items;
                rptTest.DataBind();
