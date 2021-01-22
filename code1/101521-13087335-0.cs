    **<Countries>
      <Country name ="ANDORRA">
        <state>Andorra (general)</state>
        <state>Andorra</state>
      </Country>
      <Country name ="United Arab Emirates">
        <state>Abu Z¸aby</state>
        <state>Umm al Qaywayn</state>
      </Country>**
    
    
    
     public void datass(string file)
      {
    
                string file = HttpContext.Current.Server.MapPath("~/App_Data/CS.xml");
                    XmlDocument doc = new XmlDocument();
                    if (System.IO.File.Exists(file))
                    {
                        //Load the XML File
                        doc.Load(file);
    
                    }
    
    
                    //Get the root element
                    XmlElement root = doc.DocumentElement;
                    XmlNodeList subroot = root.SelectNodes("Country");
    
                    for (int i = 0; i < subroot.Count; i++)     
                    {
    
                        XmlNode elem = subroot.Item(i);
                        string attrVal = elem.Attributes["name"].Value;
                        Response.Write(attrVal);
                        XmlNodeList sub = elem.SelectNodes("state");
                        for (int j = 0; j < sub.Count; j++)
                        {
                            XmlNode elem1 = sub.Item(j);
                            Response.Write(elem1.InnerText);
    
                        }
                    }
    
        }
