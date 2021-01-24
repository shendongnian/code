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
            Children = GetChildren(allMenu, e.Id) /* Recursively grab the children */
        }).ToList();
        ViewBag.menusList = mi;
        return View();
    }
    /// <summary>
    /// Recursively grabs the children from the list of items for the provided parentId
    /// </summary>
    /// <param name="items">List of all items</param>
    /// <param name="parentId">Id of parent item</param>
    /// <returns>List of children of parentId</returns>
    private static List<MenuItem> GetChildren(List<MenuItem> items, int parentId)
    {
        return items
            .Where(x => x.ParentId == parentId)
            .Select(e => new MenuItem
            {
                Id = e.Id,
                Name = e.Name,
                ParentId = e.ParentId,
                Children = GetChildren(items, e.Id)
            }).ToList();
    }
