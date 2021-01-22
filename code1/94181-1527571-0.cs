    public class MenuItem
    {
        public MenuItem() { }
    
        public MenuItem(XElement xmlDoc)
        {
            this.id = xmlDoc.Element("Id").Value;
            this.url = xmlDoc.Element("Url").Value;
            // etc.
            subMenuItems = (from subMenuItem in xmlDoc.Descendants("SubItem")
                            select new SubMenuItem(subMenuItem)).ToList();
        // etc.
    }
    public class SubMenuItem
    {
        public SubMenuItem() { }
        
        public SubMenuItem(XElement xmlDoc)
        {
            this.id = xmlDoc.Element("Id").Value;
            // etc.
        }
        // etc.
    }
