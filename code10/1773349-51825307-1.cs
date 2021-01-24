    protected void Page_Load(object sender, EventArgs e)
    {
        List<MenuItem> MenuItems = new List<MenuItem>();
        for (int i = 0; i < 10; i++)
        {
            MenuItems.Add(new MenuItem() { name = "Name " + i });
            if (i == 2 || i == 5 || i == 8)
            {
                MenuItems[i].menuitems = new List<MenuItem>();
                MenuItems[i].menuitems.Add(new MenuItem() { name = "SubName 1" });
                MenuItems[i].menuitems.Add(new MenuItem() { name = "SubName 2" });
                MenuItems[i].menuitems.Add(new MenuItem() { name = "SubName 3" });
                if (i == 8)
                {
                    MenuItems[i].menuitems[0].menuitems = new List<MenuItem>();
                    MenuItems[i].menuitems[0].menuitems.Add(new MenuItem() { name = "SubName 1" });
                    MenuItems[i].menuitems[0].menuitems.Add(new MenuItem() { name = "SubName 2" });
                    MenuItems[i].menuitems[0].menuitems.Add(new MenuItem() { name = "SubName 3" });
                }
            }
        }
        Repeater1.DataSource = MenuItems;
        Repeater1.DataBind();
    }
