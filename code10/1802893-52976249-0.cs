    public class NavViewComponent : ViewComponent
        {
    
            private readonly HSCWebAppContext _context;
    
            public NavViewComponent(HSCWebAppContext context)
            {
                _context = context;
            }
    
            public IViewComponentResult Invoke()
            {
    
                NavViewModel nav = new NavViewModel();
                List<NavViewModel> navList = new List<NavViewModel>();
    
                var items = from n in _context.HSCTable select n;
                List<HSCTable> tableList = items.ToList<HSCTable>();
    
    
                for (int i = 0; i < tableList.Count(); i++)
                {
                    nav.Id = tableList[i].ID;
                    nav.DepartmentName = tableList[i].DepartmentName;
                    nav.sel = tableList[i].sel;
                    navList.Add(nav);
                }
               
                return View("_SideNav",tableList);
            }
    
        }
