    public List<MenuItem> SelectDescendants(XElement menuItem)
    {
        return from menuItem
                    select new MenuItem
                    {
                        Id = menuItem.Element("Id").Value,
                        Description = menuItem.Element("Description").Value,
                        LinkText = menuItem.Element("LinkText").Value,
                        Url = menuItem.Element("Url").Value,
                        Target = menuItem.Element("Description").Value,
                        //Recursion below!!!
                        SubMenuItems = SelectDescendants(menuItem.Descendants)
                    }).ToList();
    
    }
