    IList<Menu> menusOnForm = new List<Menu>();
    if (this.Menu != null)
    {
        menusOnForm.Add(this.Menu);
        BuildMenuList(this.Menu.MenuItems, menusOnForm);
    }
    private static void BuildMenusList(MenuItemCollection menuItems, IList<Menu> listToPopulate)
    {
        foreach (Menu menuItem in menuItems)
        {
            listToPopulate.Add(menuItem);
            BuildMenusList(menuItem.MenuItems, listToPopulate);
        }
    }
