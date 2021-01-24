    [HttpGet]
    public ActionResult Index()
    {
        return View(_db.Owners.ToList());
    }
    [HttpPost]
    public ActionResult Index(string searchString)
    {
        var owners = from o in _db.Owners select o;
        var lastName = searchString.Split(',')[0];
        var firstName = searchString.Split(',')[1].TrimStart();
        if (!String.IsNullOrEmpty(searchString))
        {
            owners = owners.Where(o => o.LastName.Contains(lastName) || o.FirstName.Contains(firstName));
        }
        return View(owners);
    }
