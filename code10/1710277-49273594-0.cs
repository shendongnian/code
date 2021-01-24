    <ul class="side-menu-list">
        <li class="grey with-sub">
            <a href="@Url.Action("Index", "Home")" class="lbl">
                Dashboard
                <span class="font-icon font-icon-dashboard lbl"></span>
            </a>
        </li>
        @if (Session["MenuMaster"] != null)
        {
            var MenuMaster = (List<MedOrbits_MVC.Models.UserModules>)Session["MenuMaster"];
            var groupByMenu = MenuMaster.GroupBy(x => new{ x.ModuleName, x.ClassName, x.IconName}).ToList();
    
            foreach (var MenuList in groupByMenu)
            {
                <li class="purple with-sub">
                    <span>
                        <i class="@MenuList.Key.IconName"></i>
                        <span class="@MenuList.Key.ClassName">@MenuList.Key.ModuleName</span>
                    </span>
                </li>
            }
        }
    </ul>
