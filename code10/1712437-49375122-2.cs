    public class MenuList
    {
    	public List<MenuData> Menus { get; private set; }
    
    	public MenuList()
    	{
    		Menus = new List<MenuData>()
    		{
    			new MenuData {
    				ID = "1",
    				Text = "Service",
    				Image = "file_path.png",
    				Expanded = false
    			},
    		};
    	}
    
    	public class MenuData : ICloneable
    	{
    		public string ID { get; set; }
    		public string Text { get; set; }
    		public string Image { get; set; }
    		public Boolean Expanded { get; set; }
    
    		public object Clone()
    		{
    			return new MenuData()
    			{
    				ID = this.ID,
    				Text = this.Text,
    				Expanded = this.Expanded,
    				Image = this.Image
    			};
    		}
    	}
    
    	public List<MenuData> CloneMenus()
    	{
    		return Menus.Select(o => (MenuData)o.Clone()).ToList();
    	}
    }
