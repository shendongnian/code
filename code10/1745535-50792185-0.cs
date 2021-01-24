    public virtual ActionResult Index()
    {
        var list = GetSubClasses<Controller>();
        // Get all controllers with their actions
        var getAllcontrollers = (from item in list
            let name = item.Name
            where !item.Name.StartsWith("T4MVC_") // I'm using T4MVC
            select new MyController()
            {
                Name = name.Replace("Controller", ""), Namespace = item.Namespace, MyActions = GetListOfAction(item)
            }).ToList();
        // Now we will get all areas that has been registered in route collection
        var getAllAreas = RouteTable.Routes.OfType<Route>()
            .Where(d => d.DataTokens != null && d.DataTokens.ContainsKey("area"))
            .Select(
                r =>
                    new MyArea
                    {
                        Name = r.DataTokens["area"].ToString(),
                        Namespace = r.DataTokens["Namespaces"] as IList<string>,
                    }).ToList()
            .Distinct().ToList();
        // Add a new area for default controllers
        getAllAreas.Insert(0, new MyArea()
        {
            Name = "Main",
            Namespace = new List<string>()
            {
                typeof (Web.Controllers.HomeController).Namespace
            }
        });
        foreach (var area in getAllAreas)
        {
            var temp = new List<MyController>();
            foreach (var item in area.Namespace)
            {
                temp.AddRange(getAllcontrollers.Where(x => x.Namespace == item).ToList());
            }
            area.MyControllers = temp;
        }
        return View(getAllAreas);
    }
    private static List<Type> GetSubClasses<T>()
    {
        return Assembly.GetCallingAssembly().GetTypes().Where(
            type => type.IsSubclassOf(typeof(T))).ToList();
    }
    private IEnumerable<MyAction> GetListOfAction(Type controller)
    {
        var navItems = new List<MyAction>();
        // Get a descriptor of this controller
        ReflectedControllerDescriptor controllerDesc = new ReflectedControllerDescriptor(controller);
        // Look at each action in the controller
        foreach (ActionDescriptor action in controllerDesc.GetCanonicalActions())
        {
            bool validAction = true;
            bool isHttpPost = false;
            // Get any attributes (filters) on the action
            object[] attributes = action.GetCustomAttributes(false);
            // Look at each attribute
            foreach (object filter in attributes)
            {
                // Can we navigate to the action?
                if (filter is ChildActionOnlyAttribute)
                {
                    validAction = false;
                    break;
                }
                if (filter is HttpPostAttribute)
                {
                    isHttpPost = true;
                }
            }
            // Add the action to the list if it's "valid"
            if (validAction)
                navItems.Add(new MyAction()
                {
                    Name = action.ActionName,
                    IsHttpPost = isHttpPost
                });
        }
        return navItems;
    }
    public class MyAction
    {
        public string Name { get; set; }
        public bool IsHttpPost { get; set; }
    }
    public class MyController
    {
        public string Name { get; set; }
        public string Namespace { get; set; }
        public IEnumerable<MyAction> MyActions { get; set; }
    }
    public class MyArea
    {
        public string Name { get; set; }
        public IEnumerable<string> Namespace { get; set; }
        public IEnumerable<MyController> MyControllers { get; set; }
    }
