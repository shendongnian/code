    void Main()
    {
        DataContext dc = new DataContext();
        menuXML = new XDocument();
        XElement root = new XElement("menuxml",
            from m in dc.Menus
            where m.ParentID == null
            select GetMenuXML(m));
    
        menuXML.Add(root);
        // You've now got an XML document that you can do with as you need
        // For test you can save...
        menuXML.Save("filename.xml");
    }
    
    private static XElement GetMenuXML(Menu menu) 
    { 
        return new XElement("category",  
            new XAttribute("MenuID", menu.MenuID), 
            new XAttribute("Text", menu.Text), 
            new XElement("Description", menu.Description), 
            new XElement("menus", menu.Menus.Select(m => GetMenuXML(m)))); 
    }
