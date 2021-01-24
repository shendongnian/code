    @{
        var menuList = ViewBag.menusList as List<Scaffolding.Controllers.MenuItem>;
        @ShowTree(menuList);
    }
    
    @helper ShowTree(List<Scaffolding.Controllers.MenuItem> menusList)
    {
        if (menusList != null)
        {
            foreach (var item in menusList)
            {
                <li>
                    <span>@item.Name</span>
                    @if (item.Children.Any())
                    {
                        <ul>
                            @ShowTree(item.Children)
                        </ul>
                    }
                </li>
            }
        }
    }
