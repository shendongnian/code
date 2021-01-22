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
    
    private XElement GetMenuXML(Menu menu)
    {
    	return new XElement("menu",
             XAttribute("MenuID", menu.MenuID),
             XAttribute("Text", menu.Text),
             XElement("Description", Description),
             XElement("menus", menu.ChildMenus.Select(m => GetMenuXML(m)))
             );
    }
