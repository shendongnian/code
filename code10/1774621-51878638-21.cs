      @{
        if (Session["MenuList"] != null)
        {
            <div class="sidebar-menu">
                @GetTreeMenus(Session["MenuList"] as IEnumerable<WebApplicationMVC.Models.MenuMaster>, 0)
            </div>
        }
    }
