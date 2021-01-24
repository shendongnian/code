    @helper GetTreeMenus(IEnumerable<WebApplicationMVC.Models.MenuMaster> siteMenu, Nullable<int> parentID)
        {
            foreach (var i in siteMenu.Where(a => a.ParentId.Equals(parentID)))
            {
                var submenu = siteMenu.Where(a => a.ParentId.Equals(i.MenuId)).Count();
    
                string action = i.ActionName;
                string controller = i.ControllerName;
    
                <ul class="treeview-menu">
                    <li class="treeview">
                        <a href="/@i.ControllerName/@i.ActionName">
                            <i class="fa fa-angle-double-right"></i> <span>@i.MenuText</span>
                            <i class="fa fa-angle-left pull-right"></i>
                        </a>
                    </li>
                    @GetTreeMenus(siteMenu, i.MenuId)
                </ul>
            }
        }
