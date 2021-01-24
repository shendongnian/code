    @helper ShowTree(List<Scaffolding.Controllers.MenuItem> menusList)
    {
        <ul>
            @foreach (var item in menusList)
            {
                <li>
                    <span>@item.Name</span>
                    @if (item.Children!=null && item.Children.Any())
                    {
                        @ShowTree(item.Children)
                    }
                </li>
            }
        </ul>
    }
    
    @{
        var menuList = ViewBag.menusList as List<Scaffolding.Controllers.MenuItem>;
        @ShowTree(menuList);
    }
    public ActionResult Index()
    {
        
        List<MenuItem> allMenu = new List<MenuItem>
        {
            new MenuItem {Id=1,Name="Parent 1", ParentId=0},
            new MenuItem {Id=2,Name="child 1", ParentId=1},
            new MenuItem {Id=3,Name="child 2", ParentId=1},
            new MenuItem {Id=4,Name="child 3", ParentId=1},
            new MenuItem {Id=5,Name="Parent 2", ParentId=0},
            new MenuItem {Id=6,Name="child 4", ParentId=4}
        };
        List<MenuItem> mi = allMenu
        .Where(e => e.ParentId == 0) /* grab only the root parent nodes */
        .Select(e => new MenuItem
        {
            Id = e.Id,
            Name = e.Name,
            ParentId = e.ParentId,
            Children = allMenu.Where(x => x.ParentId == e.Id).ToList()
        }).ToList();
        ViewBag.menusList = mi;
        return View();
    }
    public class MenuItem 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public virtual List<MenuItem> Children { get; set; }
    }
