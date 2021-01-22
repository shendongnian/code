    public class MenuItem
    {
        public string LinkUrl { get; set; }
        public string LinkName { get; set; }
    }
    
    public void Page_Load()
    {
        //GetMenuItems would populate this list, depending on your logic
        List<MenuItem> menuItems = GetMenuItems(menuId);
        rptMenu.DataSource = menuItems;
        rptMenu.DataBind()
    }
