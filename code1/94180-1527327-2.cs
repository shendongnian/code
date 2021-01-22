	class Program
	{
		static void Main(string[] args)
		{
			var doc = XDocument.Load("input.xml");
			var menuItems = SelectDescendants(doc.Elements("MenuItems").Elements());
		}
		public static List<MenuItem> SelectDescendants(IEnumerable<XElement> menuItems)
		{
			return (from menuItem in menuItems
						select new MenuItem
						{
							Id = menuItem.Attribute("Id").Value,
							Description = menuItem.Attribute("Description").Value,
							LinkText = menuItem.Attribute("LinkText").Value,
							Url = menuItem.Attribute("Url").Value,
							Target = menuItem.Attribute("Description").Value,
							SubMenuItems = SelectDescendants(menuItem.Elements()).ToList()
						}).ToList();
		}
	}
