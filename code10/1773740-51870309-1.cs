    protected void Rep_BindMenuItem_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
        {
            tblMenuCategory dataItem = (tblMenuCategory)e.Item.DataItem;
            **HyperLink Menu * * = (HyperLink)e.Item.FindControl("HyperLinkMenu");
            Menu.Text = dataItem.MenuCategory;
            int MenuId = dataItem.MenuCategoryID;
    
            //Get menu by calling below method with menuid
            MyMenu myMenu = GetMenuById(MenuId);
    
            Repeater repeatercategory = (Repeater)e.Item.FindControl("RepBindMenuCategItem");
            repeatercategory.DataSource = BLCategory.CategoryLoadByMenuId(MenuId);
            repeatercategory.DataBind();
    
            //Bind those menu data to below parameters values 
            Response.RedirectToRoute("Selected Menu", new { Menuname = myMenu.MenuText, mc = myMenu.MC, cs = myMenu.CS, mid = myMenu.MID });
        }
    }
